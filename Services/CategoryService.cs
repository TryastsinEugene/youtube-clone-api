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

		public CategoryDto CreateCategory(CategoryForCreationDto categoryDto)
		{
			var categoryEntity = new Category(categoryDto.Name, categoryDto.Description);
			
			_repository.Category.CreateCategory(categoryEntity);
			_repository.Save();

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

		public IEnumerable<CategoryDto> GetAllCategories(bool trackChanges)
		{
				var categories = _repository.Category.GetAllCategories(trackChanges);
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

		public CategoryDto GetCategory(Guid categoryId, bool trackChanges)
		{
			var category = _repository.Category.GetCategory(categoryId, trackChanges);
			if (category is null)
				throw new CategoryNotFoundException(categoryId);

			var categoryDto = new CategoryDto(category.Id, category.Name, category.Description, category.CreatedAt, category.UpdatedAt);

			return categoryDto;
		}
	}
}
