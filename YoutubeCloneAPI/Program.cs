using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Presentation.ActionFilters;
using YoutubeCloneAPI.Extensions;

namespace YoutubeCloneAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(),
				"/nlog.config"));
			// Add services to the container.
			builder.Services.ConfigureCors();
			builder.Services.ConfigureLoggerService();
			builder.Services.ConfigureRepositoryManager();
			builder.Services.ConfigureServiceManager();
			builder.Services.ConfigureSqlContext(builder.Configuration);

			builder.Services.Configure<ApiBehaviorOptions>(options =>
			{
				options.SuppressModelStateInvalidFilter = true; // Disable default model state validation
			});

			builder.Services.AddScoped<ValidationFilterAttribute>();

			builder.Services.AddControllers()
				.AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

			builder.Services.AddAuthentication();
			builder.Services.ConfigureIdentity();
			builder.Services.ConfigureJWT(builder.Configuration);
			var app = builder.Build();


			// Configure the HTTP request pipeline.
			var logger = app.Services.GetRequiredService<ILoggerManager>();
			app.ConfigureExceptionHandler(logger);

			if(app.Environment.IsProduction())
				app.UseHsts();

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCors("CorsPolicy");

			app.UseAuthentication();
			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
