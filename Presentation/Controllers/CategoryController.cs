using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Service.Abstractions;
using Shared.DTOs;
using Shared.RequestFeatures;

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
		[Authorize]
		public async Task<IActionResult> GetCategories([FromQuery] CategoryParameters categoryParameters)
		{
			var pagedResult = await _service.CategoryService.GetAllCategoriesAsync(categoryParameters, trackChanges: false);

			Response.Headers.Add("X-Pagination", System.Text.Json.JsonSerializer.Serialize(pagedResult.metaData));

			return Ok(pagedResult.categories);
		}

		[HttpGet("{id:guid}", Name = "CategoryById")]
		public async Task<IActionResult> GetCategory(Guid id)
		{
			var category = await _service.CategoryService.GetCategoryAsync(id, trackChanges: false);
			
			return Ok(category);
		}

		[HttpPost]
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreationDto category)
		{
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
		[ServiceFilter(typeof(ValidationFilterAttribute))]
		public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] CategoryForUpdateDto category)
		{
			await _service.CategoryService.UpdateCategoryAsync(id, category, trackChanges: true);

			return NoContent();
		}
	}
	
}
