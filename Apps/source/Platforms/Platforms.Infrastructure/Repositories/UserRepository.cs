using System;
using Platforms.Domain.Entities;
using Platforms.Infrastructure.EFCore;
using Platforms.Infrastructure.Repositories.Base;
using Platforms.Infrastructure.Repositories.Interfaces;

namespace Platforms.Infrastructure.Repositories
{
	public class UserRepository:EFRepository<User,PlatformContext>,IUserRepository
	{
		
	}
}

