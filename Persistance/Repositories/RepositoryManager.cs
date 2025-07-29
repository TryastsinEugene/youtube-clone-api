using Domain.Repositories;

namespace Persistance.Repositories
{
	public sealed class RepositoryManager : IRepositoryManager
	{
		private readonly RepositoryDbContext _context;
		private readonly Lazy<ICategoryRepository> _categoryRepository;

		public RepositoryManager(RepositoryDbContext context)
		{
			_context = context;
			_categoryRepository = new Lazy<ICategoryRepository>(() =>
			new CategoryRepository(context));
		}
		
		public ICategoryRepository Category => _categoryRepository.Value;

		public async Task SaveAsync() => await _context.SaveChangesAsync();

	}
}
