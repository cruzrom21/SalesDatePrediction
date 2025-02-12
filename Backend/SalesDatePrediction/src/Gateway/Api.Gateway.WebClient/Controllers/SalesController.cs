using Api.Gateway.Models;
using Api.Gateway.Proxies.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Gateway.WebClient.Controllers
{
	[ApiController]
	[Route("sales")]
	public class SalesController : Controller
	{
		private readonly ISalesProxy _salesProxy;
		public SalesController(ISalesProxy salesProxy)
		{
			_salesProxy = salesProxy;
		}

		[HttpGet("GetSalesDatePrediction")]
		public async Task<List<GetSalesDatePrediction>?> GetSalesDatePrediction()
		{
			return await _salesProxy.GetSalesDatePrediction();
		}

		[HttpGet("GetSalesDatePredictionFilter")]
		public async Task<List<GetSalesDatePrediction>?> GetSalesDatePredictionFilter(string CustName)
		{
			return await _salesProxy.GetSalesDatePredictionFilter(CustName);
		}

		[HttpGet("GetClientOrders")]
		public async Task<List<GetClientOrder>?> GetClientOrders(int custid)
		{
			return await _salesProxy.GetClientOrder(custid);
		}

		[HttpPost]
		[Route("AddNewOrder")]
		public async Task<bool> AddNewOrder(NewOrderDTO newOrder)
		{
			return await _salesProxy.AddNewOrder(newOrder);
		}

		[HttpGet("GetShippers")]
		public async Task<List<GetShipper>?> GetShippers()
		{
			return await _salesProxy.GetShippers();
		}

	}
}
