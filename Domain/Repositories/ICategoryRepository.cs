using Domain.Entities;

namespace Domain.Repositories
{
	public interface ICategoryRepository
	{
		Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);
		Task<Category> GetCategoryAsync(Guid categoryId, bool trackChanges);
		void CreateCategory(Category category);
		void DeleteCategory(Category category);
	}
}
