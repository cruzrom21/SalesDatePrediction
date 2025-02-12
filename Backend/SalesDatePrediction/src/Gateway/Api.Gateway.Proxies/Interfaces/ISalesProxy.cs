using Api.Gateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Proxies.Interfaces
{
	public interface ISalesProxy
	{
		Task<List<GetSalesDatePrediction>?> GetSalesDatePrediction();
		Task<List<GetSalesDatePrediction>?> GetSalesDatePredictionFilter(string CustName);
		Task<List<GetClientOrder>?> GetClientOrder(int custid);
		Task<bool> AddNewOrder(NewOrderDTO newOrder);
		Task<List<GetShipper>?> GetShippers();

	}
}
