using Microsoft.AspNetCore.Mvc;
using Production.Models.Domain;
using Production.Services.Products.Interfaces;

namespace Production.Api.Controllers
{
	[ApiController]
	[Route("production")]
	public class ProductsController : ControllerBase
	{
		private IProductServices _productServices;

		public ProductsController(IProductServices productServices)
		{
			_productServices = productServices;
		}

		[HttpGet("GetProducts")]
		public ActionResult<List<GetProduct>?> GetProducts()
		{
			try
			{
				return _productServices.GetProducts();
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult(new { message = ex.Message });
			}
		}
	}
}
