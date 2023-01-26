using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Platforms.Domain.Entities;
using Platforms.Domain.Enums;
using Platforms.Infrastructure.Utils;

namespace Platforms.Infrastructure.EFCore
{
    public class PlatformContext : DbContext
    {
        private IConfiguration configuration;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //For Migration
            //optionsBuilder.UseSqlServer(@"DatabaseConnectingString");

            configuration = new ConfigurationBuilder()
              .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json")
               .Build();
            bool systemIsLive = Convert.ToBoolean(configuration["AppSettings:SystemIsLive"]);

#if DEBUG
            if (systemIsLive)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("TEST"));
            }
            else
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("TEST"));
            }
#else
  if (systemIsLive)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("PROD"));
            }
            else
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("TEST"));
            }
#endif



        }
        public override int SaveChanges()
        {
            BeforeSaveChanges();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            BeforeSaveChanges();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        private void BeforeSaveChanges()
        {
            var auditEntries = new List<AuditEntry>();
            //For the audit log
            ChangeTracker.DetectChanges();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;
                var auditEntry = new AuditEntry(entry);
                auditEntries.Add(auditEntry);

                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.AuditType = AuditType.Create;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            auditEntry.UserId = entry.Property("CreatedBy").CurrentValue != null ? entry.Property("CreatedBy").CurrentValue.ToString() : "Null";
                            break;

                        case EntityState.Deleted:
                            auditEntry.AuditType = AuditType.Delete;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            auditEntry.UserId = entry.Property("LastModifiedBy").CurrentValue != null ? entry.Property("LastModifiedBy").CurrentValue.ToString() : "Null";
                            break;

                        case EntityState.Modified:
                            auditEntry.AuditType = AuditType.Update;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            auditEntry.UserId = entry.Property("LastModifiedBy").CurrentValue != null ? entry.Property("LastModifiedBy").CurrentValue.ToString() : "Null";
                            break;
                    }
                }
            }

            foreach (var auditEntry in auditEntries)
            {
                AuditLogs.Add(auditEntry.ToAudit());
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //To make unique Email field on User Entity model. 
            modelBuilder.Entity<User>()
                .HasIndex(p => p.Email)
                .IsUnique();
        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Right> Right { get; set; }
        public DbSet<Audit> AuditLogs { get; set; }


    }
}

