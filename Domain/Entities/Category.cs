using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
	public class Category
	{
		[Column("CategoryId")]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Company name is a required field.")]
		[MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
		public string Name { get; set; }

		public string Description { get; set; }
		public string CreatedAt { get; set; } = DateTime.Now.ToString("g");
		public string? UpdatedAt { get; set; }

		public Category() { }

		public Category(string name, string description)
		{
			Name = name;
			Description = description;
			UpdatedAt = DateTime.Now.ToString("g");
		}
	}
}
