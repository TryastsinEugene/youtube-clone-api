

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasData
				(
					new Category
					{
						Id = Guid.NewGuid(),
						Name = "Technology",
						Description = "All about technology, gadgets, and innovations.",
						CreatedAt = DateTime.Now.ToString("g"),
						UpdatedAt = null
					}
				);
		}
	}
}
