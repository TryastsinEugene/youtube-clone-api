using Domain.Entities;
using Domain.Repositories;
using LoggerService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Persistance.Repositories;
using Service.Abstractions;
using Services;

namespace YoutubeCloneAPI.Extensions
{
	public static class ServiceExtensions
	{
		public static void ConfigureCors(this IServiceCollection services) =>
			services.AddCors(options => 
			{ 
				options.AddPolicy("CorsPolicy", builder =>
				builder.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader()); 
			});

		public static void ConfigureLoggerService(this IServiceCollection services) => 
			services.AddSingleton<ILoggerManager, LoggerManager>();

		public static void ConfigureRepositoryManager(this IServiceCollection services) => 
			services.AddScoped<IRepositoryManager, RepositoryManager>();

		public static void ConfigureServiceManager(this IServiceCollection services) => 
			services.AddScoped<IServiceManager, ServiceManager>();

		public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
			services.AddDbContext<RepositoryDbContext>(opts => 
			opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));


		public static void ConfigureIdentity(this IServiceCollection services) 
		{
			var builder = services.AddIdentity<User, IdentityRole>(o => 
			{
				o.Password.RequireDigit = true; 
				o.Password.RequireLowercase = false; 
				o.Password.RequireUppercase = false; 
				o.Password.RequireNonAlphanumeric = false; 
				o.Password.RequiredLength = 10; 
				o.User.RequireUniqueEmail = true; 
			}).AddEntityFrameworkStores<RepositoryDbContext>().AddDefaultTokenProviders(); }
	}
}
