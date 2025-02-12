using Microsoft.EntityFrameworkCore;
using Production.Models.Domain;
using Production.Persistence.Database;
using Production.Services.Products;

namespace Production.Test
{
	public class ProductServicesTest
	{
		private readonly StoreSampleContext _dbContext;
		private readonly ProductServices _service;

		public ProductServicesTest()
		{
			var options = new DbContextOptionsBuilder<StoreSampleContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
				.Options;

			_dbContext = new StoreSampleContext(options);

			// Insertar datos de prueba
			DataDB();

			_service = new ProductServices(_dbContext);
		}

		private void DataDB()
		{
			List<GetProduct> products = new List<GetProduct>
			{
				new GetProduct { Productid = 58, Productname = "Product ACRVI" },
				new GetProduct { Productid = 9, Productname = "Product AOZBW" },
				new GetProduct { Productid = 51, Productname = "Product AOZBW" },
			};

			_dbContext.GetProducts.AddRange(products);
			_dbContext.SaveChanges();
		}


		[Fact]
		public void GetSalesDatePrediction()
		{
			var result = _service.GetProducts();

			Assert.NotNull(result);
			Assert.Equal(3, result.Count);
		}
	}
}