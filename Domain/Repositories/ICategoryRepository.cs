using Domain.Entities;
using Shared.RequestFeatures;

namespace Domain.Repositories
{
	public interface ICategoryRepository
	{
		Task<PagedList<Category>> GetAllCategoriesAsync(CategoryParameters categoryParameters, bool trackChanges);
		Task<Category> GetCategoryAsync(Guid categoryId, bool trackChanges);
		void CreateCategory(Category category);
		void DeleteCategory(Category category);
	}
}
