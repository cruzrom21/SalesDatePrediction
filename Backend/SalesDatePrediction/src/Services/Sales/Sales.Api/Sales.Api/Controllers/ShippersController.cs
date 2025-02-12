using Microsoft.AspNetCore.Mvc;
using Sales.Models.Domain;
using Sales.Services.Shippers.Interfaces;

namespace Sales.Api.Controllers
{
	[ApiController]
	[Route("sales")]
	public class ShippersController : ControllerBase
	{
		private IShipperServices _shipperServices;

		public ShippersController(IShipperServices shipperServices)
		{
			_shipperServices = shipperServices;
		}

		[HttpGet("GetShippers")]
		public ActionResult<List<GetShipper>?> GetShippers()
		{
			try
			{
				return _shipperServices.GetShippers();
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult(new { message = ex.Message });
			}
		}
	}
}
