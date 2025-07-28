using Domain.Repositories;
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
		public IActionResult GetCategories()
		{
			var categories = _service.CategoryService.GetAllCategories(trackChanges: false);

			return Ok(categories);
		}

		[HttpGet("{id:guid}", Name = "CategoryById")]
		public IActionResult GetCategory(Guid id)
		{
			var category = _service.CategoryService.GetCategory(id, trackChanges: false);
			
			return Ok(category);
		}

		[HttpPost]
		public IActionResult CreateCategory([FromBody] CategoryForCreationDto category)
		{
			if(category is null)
				return BadRequest("Category data is null.");

			var createdCategory = _service.CategoryService.CreateCategory(category);

			return CreatedAtRoute("CategoryById", new { id = createdCategory.Id }, createdCategory);
		}
	}
	
}
