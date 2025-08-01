
using Shared.DTOs;
using Shared.RequestFeatures;

namespace Service.Abstractions
{
	public interface ICategoryService
	{
		Task<(IEnumerable<CategoryDto> categories, MetaData metaData)> GetAllCategoriesAsync(CategoryParameters categoryParameters ,bool trackChanges);
		Task<CategoryDto> GetCategoryAsync(Guid categoryId, bool trackChanges);
		Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto categoryDto);
		Task UpdateCategoryAsync(Guid categoryId, CategoryForUpdateDto categoryDto, bool trackChanges);	
		Task DeleteCategoryAsync(Guid categoryId, bool trackChanges);
	}
}
