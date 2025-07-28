namespace Shared.DTOs
{
	public record class CategoryDto(Guid Id, string Name, string Description, string CreatedAt, string? UpdatedAt);
	
}
