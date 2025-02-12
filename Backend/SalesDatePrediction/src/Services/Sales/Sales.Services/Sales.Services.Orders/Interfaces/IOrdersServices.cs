using Sales.Models.Domain;
using Sales.Persistence.Database;

namespace Sales.Services.Orders.Interfaces
{
	public interface IOrdersServices
	{
		List<GetSalesDatePrediction> GetSalesDatePrediction();
		List<GetSalesDatePrediction> GetSalesDatePredictionFilter(string CustName);
		List<GetClientOrder> GetClientOrders(int custid);
		bool AddNewOrder(NewOrderDTO newOrder);
	}
}
