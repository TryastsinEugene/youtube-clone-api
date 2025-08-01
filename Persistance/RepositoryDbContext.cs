using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistance.Configurations;

namespace Persistance
{
	public class RepositoryDbContext : IdentityDbContext<User>
	{
		public RepositoryDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfiguration(new CategoryConfiguration());
			builder.ApplyConfiguration(new RoleConfiguration());
		}

		public DbSet<Category>? Categories { get; set; }
	}
}
