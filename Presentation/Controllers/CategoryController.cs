using Microsoft.AspNetCore.Mvc;
using Service.Abstractions;
using Shared.DTOs;

namespace Presentation.Controllers
{
	[ApiController]
	[Route("api/categories")]
	public class CategoriesController : ControllerBase
	{
		private readonly IServiceManager _service;

		public CategoriesController(IServiceManager service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetCategories()
		{
			var categories = await _service.CategoryService.GetAllCategoriesAsync(trackChanges: false);

			return Ok(categories);
		}

		[HttpGet("{id:guid}", Name = "CategoryById")]
		public async Task<IActionResult> GetCategory(Guid id)
		{
			var category = await _service.CategoryService.GetCategoryAsync(id, trackChanges: false);
			
			return Ok(category);
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreationDto category)
		{
			if(category is null)
				return BadRequest("Category data is null.");

			if(!ModelState.IsValid)
				return UnprocessableEntity(ModelState);

			var createdCategory = await _service.CategoryService.CreateCategoryAsync(category);

			return CreatedAtRoute("CategoryById", new { id = createdCategory.Id }, createdCategory);
		}

		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteCategory(Guid id)
		{
			await _service.CategoryService.DeleteCategoryAsync(id, trackChanges: false);
			return NoContent();
		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] CategoryForUpdateDto category)
		{
			if (category is null)
				return BadRequest("Category data is null.");


			if (!ModelState.IsValid)
				return UnprocessableEntity(ModelState);

			await _service.CategoryService.UpdateCategoryAsync(id, category, trackChanges: true);

			return NoContent();
		}
	}
	
}
