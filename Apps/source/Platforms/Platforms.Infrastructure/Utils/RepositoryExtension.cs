using System;
using Microsoft.Extensions.DependencyInjection;
using Platforms.Infrastructure.Repositories;
using Platforms.Infrastructure.Repositories.Interfaces;

namespace Platforms.Infrastructure.Utils
{
	public  static class RepositoryExtension
	{
        public static void ConfigureInjections(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRightRepository, RightRepository>();
            services.AddScoped<IAuditRepository, AuditRepository>();
           
        }
    }
}

