
using Shared.DTOs;

namespace Service.Abstractions
{
	public interface ICategoryService
	{
		Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges);
		Task<CategoryDto> GetCategoryAsync(Guid categoryId, bool trackChanges);
		Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto categoryDto);
		Task UpdateCategoryAsync(Guid categoryId, CategoryForUpdateDto categoryDto, bool trackChanges);	
		Task DeleteCategoryAsync(Guid categoryId, bool trackChanges);
	}
}
