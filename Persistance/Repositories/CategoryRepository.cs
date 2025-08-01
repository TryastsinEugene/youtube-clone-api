using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Persistance.Repositories
{
	public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
	{
		public CategoryRepository(RepositoryDbContext context) : base(context)
		{
		}

		public void CreateCategory(Category category) => Create(category);

		public void DeleteCategory(Category category) => Delete(category);

		public async Task<PagedList<Category>> GetAllCategoriesAsync(CategoryParameters categoryParameters, bool trackChanges)
		{
			var categories = await FindAll(trackChanges)
				.OrderBy(c => c.Name)
				.ToListAsync();

			return PagedList<Category>.ToPagedList(categories, categoryParameters.PageNumber, categoryParameters.PageSize);
		}
			

		public async  Task<Category> GetCategoryAsync(Guid categoryId, bool trackChanges) =>
			await FindByCondition(c => c.Id.Equals(categoryId), trackChanges)
			.SingleOrDefaultAsync();

	}
	
}
