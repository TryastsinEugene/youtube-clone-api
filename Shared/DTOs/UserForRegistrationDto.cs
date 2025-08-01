using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
	public record UserForRegistrationDto
	{
		public Guid? ClerkId { get; set; }
		public string? ImageUrl { get; set; }
		[Required(ErrorMessage = "Username is required.")]
		public string? UserName { get; init; }
		[Required(ErrorMessage = "Email is required.")]
		public string? Email { get; init; }
		public string? Password { get; init; }
		public string? PhoneNumber { get; init; }
		public ICollection<string>? Roles { get; init; } 
	}
}
