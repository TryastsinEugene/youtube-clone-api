using Domain.Repositories;
using Service.Abstractions;

namespace Services
{
	public sealed class ServiceManager : IServiceManager
	{
		private readonly Lazy<ICategoryService> _categoryService;

		public ServiceManager(IRepositoryManager repositoryManager)
		{
			_categoryService = new Lazy<ICategoryService>(() => 
			new CategoryService(repositoryManager));
		}

		public ICategoryService CategoryService => _categoryService.Value;
	}
}
