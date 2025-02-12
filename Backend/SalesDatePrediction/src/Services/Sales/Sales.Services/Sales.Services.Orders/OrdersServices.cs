using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Sales.Models.Domain;
using Sales.Persistence.Database;
using Sales.Services.Orders.Interfaces;

namespace Sales.Services.Orders
{
	public class OrdersServices : IOrdersServices
	{
		private StoreSampleContext _db;

		public OrdersServices(StoreSampleContext dbContext)
		{
			_db = dbContext;
		}

		public List<GetSalesDatePrediction> GetSalesDatePrediction()
		{
			try
			{
				List<GetSalesDatePrediction> getSalesDatePredictions = _db.GetSalesDatePredictions.ToList();

				return getSalesDatePredictions;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public List<GetSalesDatePrediction> GetSalesDatePredictionFilter(string CustName)
		{
			try
			{
				List<GetSalesDatePrediction> getSalesDatePredictions = _db.GetSalesDatePredictions
																	.Where(x => x.CustomerName.ToLower().Contains(CustName.ToLower()))
																	.ToList();

				return getSalesDatePredictions;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public List<GetClientOrder> GetClientOrders(int custid)
		{
			try
			{
				List<GetClientOrder> clientOrders = _db.GetClientOrders.Where(x => x.Custid == custid).ToList();

				return clientOrders;
			}
			catch (Exception)
			{
				throw;
			}
		}


		public bool AddNewOrder(NewOrderDTO newOrder)
		{
			try
			{
				Order order = new Order()
				{
					Custid = newOrder.Custid,
					Empid = newOrder.Empid,
					Orderdate = newOrder.Orderdate,
					Requireddate = newOrder.Requireddate,
					Shippeddate = newOrder.Shippeddate,
					Shipperid = newOrder.Shipperid,
					Freight = newOrder.Freight,
					Shipname = newOrder.Shipname,
					Shipaddress = newOrder.Shipaddress,
					Shipcity = newOrder.Shipcity,
					Shipregion = newOrder.Shipregion,
					Shippostalcode = newOrder.Shippostalcode,
					Shipcountry = newOrder.Shipcountry
				};

				_db.Orders.Add(order);
				_db.SaveChanges();


				OrderDetail detail = new OrderDetail()
				{
					Orderid = order.Orderid,
					Productid = newOrder.Productid,
					Unitprice = newOrder.Unitprice,
					Qty = newOrder.Qty,
					Discount = newOrder.Discount
				};
				_db.OrderDetails.Add(detail);
				
				return _db.SaveChanges() > 0;
			}
			catch (Exception)
			{
				throw;
			}
		}


		//public int AddNewOrder(NewOrderDTO newOrder)
		//{
		//	try
		//	{
		//		var parameters = new[]
		//		{
		//			new SqlParameter("@custid", newOrder.Custid),
		//			new SqlParameter("@empid", newOrder.Empid),
		//			new SqlParameter("@orderdate", newOrder.Orderdate),
		//			new SqlParameter("@requireddate", newOrder.Requireddate),
		//			new SqlParameter("@shippeddate", newOrder.Shippeddate),
		//			new SqlParameter("@shipperid", newOrder.Shipperid),
		//			new SqlParameter("@freight", newOrder.Freight),
		//			new SqlParameter("@shipname", newOrder.Shipname),
		//			new SqlParameter("@shipaddress", newOrder.Shipaddress),
		//			new SqlParameter("@shipcity", newOrder.Shipcity),
		//			new SqlParameter("@shipregion", newOrder.Shipregion),
		//			new SqlParameter("@shippostalcode", newOrder.Shippostalcode),
		//			new SqlParameter("@shipcountry", newOrder.Shipcountry),
		//			new SqlParameter("@productid", newOrder.Productid),
		//			new SqlParameter("@unitprice", newOrder.Unitprice),
		//			new SqlParameter("@qty", newOrder.Qty),
		//			new SqlParameter("@discount", newOrder.Discount),
		//		};

		//		int result = _db.Database
		//			.ExecuteSqlRaw(
		//				"EXEC AddNewOrder " +
		//				"@custid," +
		//				"@empid, " +
		//				"@orderdate, " +
		//				"@requireddate, " +
		//				"@shippeddate, " +
		//				"@shipperid, " +
		//				"@freight, " +
		//				"@shipname, " +
		//				"@shipaddress, " +
		//				"@shipcity, " +
		//				"@shipregion, " +
		//				"@shippostalcode, " +
		//				"@shipcountry, " +
		//				"@productid, " +
		//				"@unitprice, " +
		//				"@qty, " +
		//				"@discount",
		//				parameters
		//			);

		//		return result;
		//	}
		//	catch (Exception)
		//	{

		//		throw;
		//	}
		//}
	}
}
