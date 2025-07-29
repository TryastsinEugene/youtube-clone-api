using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
	public abstract record CategoryForManipulationDto
	{
		[Required(ErrorMessage = "Category name is required field.")]
		[MaxLength(30, ErrorMessage = "Category name must not exceed 30 characters.")]
		public string Name { get; init; }

		[Required(ErrorMessage = "Description name is required field.")]
		[MaxLength(70, ErrorMessage = "Description name must not exceed 70 characters.")]
		public string Description { get; init; }
	}
}
