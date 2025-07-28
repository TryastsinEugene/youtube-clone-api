using Domain.Entities;

namespace Domain.Repositories
{
	public interface ICategoryRepository
	{
		IEnumerable<Category> GetAllCategories(bool trackChanges);
		Category GetCategory(Guid categoryId, bool trackChanges);
	}
}
