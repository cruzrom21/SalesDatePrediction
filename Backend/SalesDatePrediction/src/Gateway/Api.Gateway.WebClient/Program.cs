
using Api.Gateway.Models;
using Api.Gateway.Proxies;
using Api.Gateway.Proxies.Interfaces;

namespace Api.Gateway.WebClient
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.Configure<ApiUrls>(options => builder.Configuration.GetSection("ApiUrls").Bind(options));

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAllOrigins", builder =>
					builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
			});

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddHttpClient<ISalesProxy, SalesProxy>();
			builder.Services.AddHttpClient<IProductionProxy, ProductionProxy>();
			builder.Services.AddHttpClient<IHRProxy, HRProxy>();

			builder.Services.AddHttpContextAccessor();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			app.UseSwagger();
			app.UseSwaggerUI();

			app.UseCors("AllowAllOrigins");

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
