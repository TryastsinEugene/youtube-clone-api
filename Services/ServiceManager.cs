using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Abstractions;

namespace Services
{
	public sealed class ServiceManager : IServiceManager
	{
		private readonly Lazy<ICategoryService> _categoryService;
		private readonly Lazy<IAuthenticationService> _authenticationService;

		public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, 
			UserManager<User> userManager, IConfiguration configuration)
		{
			_categoryService = new Lazy<ICategoryService>(() => 
			new CategoryService(repositoryManager));
			_authenticationService = new Lazy<IAuthenticationService>(() =>
			new AuthenticationService(logger, userManager, configuration));
		}

		public ICategoryService CategoryService => _categoryService.Value;

		public IAuthenticationService AuthenticationService => _authenticationService.Value;
	}
}
