using Microsoft.AspNetCore.Mvc;
using Sales.Models.Domain;
using Sales.Persistence.Database;
using Sales.Services.Orders.Interfaces;

namespace Sales.Api.Controllers
{
	[ApiController]
	[Route("sales")]
	public class OrdersController : ControllerBase
	{
		private IOrdersServices _ordersServices;

		public OrdersController(IOrdersServices ordersServices)
		{
			_ordersServices = ordersServices;
		}

		[HttpGet("GetSalesDatePrediction")]
		public ActionResult<List<GetSalesDatePrediction>?> GetSalesDatePrediction()
		{
			try
			{
				return _ordersServices.GetSalesDatePrediction();
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult(new { message = ex.Message });
			}
		}

		[HttpGet("GetSalesDatePredictionFilter")]
		public ActionResult<List<GetSalesDatePrediction>?> GetSalesDatePredictionFilter(string CustName)
		{
			try
			{
				return _ordersServices.GetSalesDatePredictionFilter(CustName);
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult(new { message = ex.Message });
			}
		}

		[HttpGet("GetClientOrders")]
		public ActionResult<List<GetClientOrder>?> GetClientOrders(int custid)
		{
			try
			{
				return _ordersServices.GetClientOrders(custid);
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult(new { message = ex.Message });
			}
		}


		[HttpPost]
		[Route("AddNewOrder")]
		public ActionResult<bool> AddNewOrder(NewOrderDTO newOrder)
		{
			try
			{
				return _ordersServices.AddNewOrder(newOrder);
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult(new { message = ex.Message });
			}
		}
	}
}
