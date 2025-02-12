using Microsoft.EntityFrameworkCore;
using Sales.Models.Domain;
using Sales.Persistence.Database;
using Sales.Services.Orders;
namespace Sales.Test
{
	public class OrdersServicesTest
	{
		private readonly StoreSampleContext _dbContext;
		private readonly OrdersServices _service;

		public OrdersServicesTest()
		{
			var options = new DbContextOptionsBuilder<StoreSampleContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
				.Options;

			_dbContext = new StoreSampleContext(options);

			// Insertar datos de prueba
			DataDB();

			_service = new OrdersServices(_dbContext);
		}

		private void DataDB()
		{
			List<GetSalesDatePrediction> salesPredictions = new List<GetSalesDatePrediction>
			{
				new GetSalesDatePrediction { custid = 1, CustomerName = "Customer WVFAF", LastOrderDate = DateTime.Parse("2007-12-22"), NextPredictedOrder = DateTime.Parse("2008-03-18") },
				new GetSalesDatePrediction { custid = 2, CustomerName = "Customer XPFAF", LastOrderDate = DateTime.Parse("2008-05-05"), NextPredictedOrder = DateTime.Parse("2008-06-22") },
				new GetSalesDatePrediction { custid = 3, CustomerName = "Customer SIUIH", LastOrderDate = DateTime.Parse("2008-04-09"), NextPredictedOrder = DateTime.Parse("2008-09-07") }
			};
			_dbContext.GetSalesDatePredictions.AddRange(salesPredictions);


			List<GetClientOrder> clientOrders = new List<GetClientOrder>
			{
				new GetClientOrder { Orderid = 10643, Custid = 1, Requireddate = DateTime.Parse("2007-09-22"), Shippeddate = DateTime.Parse("2007-09-02"), Shipname = "Destination LOUIE", Shipaddress = "Obere Str. 6789", Shipcity = "Berlin" },
				new GetClientOrder { Orderid = 10692, Custid = 1, Requireddate = DateTime.Parse("2007-10-31"), Shippeddate = DateTime.Parse("2007-10-13"), Shipname = "Destination RSVRP", Shipaddress = "Obere Str. 8901", Shipcity = "Berlin" },

				new GetClientOrder { Orderid = 10926, Custid = 2, Requireddate = DateTime.Parse("2008-04-01"), Shippeddate = DateTime.Parse("2008-03-11"), Shipname = "Destination RAIGI", Shipaddress = "Avda. de la Constitución 4567", Shipcity = "México D.F." },
				new GetClientOrder { Orderid = 10759, Custid = 2, Requireddate = DateTime.Parse("2007-12-26"), Shippeddate = DateTime.Parse("2007-12-12"), Shipname = "Destination QOTQA", Shipaddress = "Avda. de la Constitución 3456", Shipcity = "México D.F." },

				new GetClientOrder { Orderid = 10507, Custid = 3, Requireddate = DateTime.Parse("2007-05-13"), Shippeddate = DateTime.Parse("2007-04-22"), Shipname = "Destination FQFLS", Shipaddress = "Mataderos  3456", Shipcity = "México D.F." },
				new GetClientOrder { Orderid = 10535, Custid = 3, Requireddate = DateTime.Parse("2007-06-10"), Shippeddate = DateTime.Parse("2007-05-21"), Shipname = "Destination FQFLS", Shipaddress = "Mataderos  3456", Shipcity = "México D.F." }
			};

			_dbContext.GetClientOrders.AddRange(clientOrders);
			_dbContext.SaveChanges();
		}


		[Fact]
		public void GetSalesDatePrediction()
		{
			var result = _service.GetSalesDatePrediction();

			Assert.NotNull(result);
			Assert.Equal(3, result.Count);
		}

		[Fact]
		public void GetSalesDatePredictionFilter()
		{
			var result = _service.GetSalesDatePredictionFilter("FAF");

			Assert.NotNull(result);
			Assert.Equal(2, result.Count);
		}

		[Fact]
		public void GetClientOrders()
		{
			var result = _service.GetClientOrders(1);

			Assert.NotNull(result);
			Assert.Equal(2, result.Count);
		}

		[Fact]
		public void AddNewOrder()
		{
			NewOrderDTO newOrder = new NewOrderDTO
			{
				Orderid = 10248,
				Custid = 85,
				Empid = 5,
				Orderdate = DateTime.Parse("2006-07-04"),
				Requireddate = DateTime.Parse("2006-08-01"),
				Shippeddate = DateTime.Parse("2006-07-16"),
				Shipperid = 3,
				Freight = 32.38m,
				Shipname = "Ship to 85-B",
				Shipaddress = "6789 rue de l'Abbaye",
				Shipcity = "Reims",
				Shipregion = null,
				Shippostalcode = "10345",
				Shipcountry = "France",
				Productid = 11,
				Unitprice = 14.00m,
				Qty = 12,
				Discount = 0.000m
			};

			bool result = _service.AddNewOrder(newOrder);

			int countOrder = _dbContext.Orders.ToList().Count();

			Assert.True(result);
			Assert.Equal(1, countOrder);
		}
	}
}