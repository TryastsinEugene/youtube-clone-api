using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Persistance;

namespace YoutubeCloneAPI.ContextFactory
{
	public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryDbContext>
	{
		public RepositoryDbContext CreateDbContext(string[] args)
		{
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			var builder = new DbContextOptionsBuilder<RepositoryDbContext>()
				.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
				b => b.MigrationsAssembly("Persistance"));

			return new RepositoryDbContext(builder.Options);
		}
	}

}
