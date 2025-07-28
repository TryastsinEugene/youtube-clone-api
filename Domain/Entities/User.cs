using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
	public class User : IdentityUser
	{
		public Guid? ClerkId { get; set; }
		public string? ImageUrl { get; set; }
		public string CreatedAt { get; set; } = DateTime.Now.ToString("g");
		public string? UpdatedAt { get; set; }
	}
}
