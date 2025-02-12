
using Microsoft.EntityFrameworkCore;
using Sales.Persistence.Database;
using Sales.Services.Orders;
using Sales.Services.Orders.Interfaces;
using Sales.Services.Shippers;
using Sales.Services.Shippers.Interfaces;

namespace Sales.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Agregar DbContext con SQL Server
			builder.Services.AddDbContext<StoreSampleContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddScoped<IShipperServices, ShipperServices>();
			builder.Services.AddScoped<IOrdersServices, OrdersServices>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
