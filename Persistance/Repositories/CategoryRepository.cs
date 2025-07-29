using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
	public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
	{
		public CategoryRepository(RepositoryDbContext context) : base(context)
		{
		}

		public void CreateCategory(Category category) => Create(category);

		public void DeleteCategory(Category category) => Delete(category);

		public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges) =>
			await FindAll(trackChanges)
				.OrderBy(c => c.Name)
				.ToListAsync();

		public async  Task<Category> GetCategoryAsync(Guid categoryId, bool trackChanges) =>
			await FindByCondition(c => c.Id.Equals(categoryId), trackChanges)
			.SingleOrDefaultAsync();

	}
	
}
