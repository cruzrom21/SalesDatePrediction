using Microsoft.EntityFrameworkCore;
using Sales.Models.Domain;
using Sales.Persistence.Database;
using Sales.Services.Shippers;

namespace Sales.Test
{
	public class ShipperServicesTest
	{
		private readonly StoreSampleContext _dbContext;
		private readonly ShipperServices _service;

		public ShipperServicesTest()
		{
			var options = new DbContextOptionsBuilder<StoreSampleContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
				.Options;

			_dbContext = new StoreSampleContext(options);

			// Insertar datos de prueba
			DataDB();

			_service = new ShipperServices(_dbContext);
		}

		private void DataDB()
		{
			List<GetShipper> shippers = new List<GetShipper>
			{
				new GetShipper { Shipperid = 1, Companyname = "Shipper GVSUA" },
				new GetShipper { Shipperid = 2, Companyname = "Shipper ETYNR" },
				new GetShipper { Shipperid = 3, Companyname = "Shipper ZHISN" }
			};
			_dbContext.GetShippers.AddRange(shippers);

			_dbContext.SaveChanges();
		}

		[Fact]
		public void GetShippers()
		{
			List<GetShipper> result = _service.GetShippers();

			Assert.NotNull(result);
			Assert.Equal(3, result.Count);
		}
	}
}
