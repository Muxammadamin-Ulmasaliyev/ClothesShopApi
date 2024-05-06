
using ClothesShopApi.Extensions;
using ClothesShopApi.Services;
using ClothesShopApi.Services.IServices;
using ClothesShopDataAccess.IRepositories;
using ClothesShopDataAccess.Repositories;
using ClothesShopDomain;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace ClothesShopApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));



			builder.Services.ConfigureCustomServices();


			builder.Services.ConfigureCors();

			builder.Host.UseSerilog((context, configuration) =>
				configuration.ReadFrom.Configuration(context.Configuration));


			/*builder.Host.UseSerilog((context, configuration) =>
					configuration
					.ReadFrom.Configuration(context.Configuration)
					.WriteTo.Console()
					.WriteTo.File("logs\\log-.txt", rollingInterval: RollingInterval.Day));*/

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
			}
			app.UseSwagger();
			app.UseSwaggerUI();

			app.UseSerilogRequestLogging();

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
