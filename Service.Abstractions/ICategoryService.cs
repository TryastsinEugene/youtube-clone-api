
using Shared.DTOs;

namespace Service.Abstractions
{
	public interface ICategoryService
	{
		IEnumerable<CategoryDto> GetAllCategories(bool trackChanges);
		CategoryDto GetCategory(Guid categoryId, bool trackChanges);
	}
}
