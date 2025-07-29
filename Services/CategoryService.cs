using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Service.Abstractions;
using Shared.DTOs;

namespace Services
{
	internal sealed class CategoryService : ICategoryService
	{
		private readonly IRepositoryManager _repository;

		public CategoryService(IRepositoryManager repository)
		{
			_repository = repository;
		}

		public async Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto categoryDto)
		{
			var categoryEntity = new Category(categoryDto.Name, categoryDto.Description);
			
			_repository.Category.CreateCategory(categoryEntity);
			await _repository.SaveAsync();

			var categoryForReturn = new CategoryDto
			(
				categoryEntity.Id,
				categoryEntity.Name,
				categoryEntity.Description,
				categoryEntity.CreatedAt,
				categoryEntity.UpdatedAt
			);

			return categoryForReturn;
		}

		public async Task DeleteCategoryAsync(Guid categoryId, bool trackChanges)
		{
			var category = await _repository.Category.GetCategoryAsync(categoryId, trackChanges);
			if(category is null)
				throw new CategoryNotFoundException(categoryId);

			_repository.Category.DeleteCategory(category);
			await _repository.SaveAsync();

		}

		public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges)
		{
				var categories = await _repository.Category.GetAllCategoriesAsync(trackChanges);
				var categoryDtos = categories.Select(c => new CategoryDto
				(
					c.Id,
					c.Name,
					c.Description,
					c.CreatedAt,
					c.UpdatedAt
				)).ToList();

				return categoryDtos;
		}

		public async Task<CategoryDto> GetCategoryAsync(Guid categoryId, bool trackChanges)
		{
			var category = await _repository.Category.GetCategoryAsync(categoryId, trackChanges);
			if (category is null)
				throw new CategoryNotFoundException(categoryId);

			var categoryDto = new CategoryDto(category.Id, category.Name, category.Description, category.CreatedAt, category.UpdatedAt);

			return categoryDto;
		}

		public async Task UpdateCategoryAsync(Guid categoryId, CategoryForUpdateDto categoryDto, bool trackChanges)
		{
			var category = await _repository.Category.GetCategoryAsync(categoryId, trackChanges);
			if( category is null)
				throw new CategoryNotFoundException(categoryId);

			category.Description = categoryDto.Description;
			category.Name = categoryDto.Name;
			category.UpdatedAt = DateTime.Now.ToString("g");

			await _repository.SaveAsync();
		}
	}
}
