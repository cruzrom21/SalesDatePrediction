using Api.Gateway.Models;
using Api.Gateway.Proxies.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Gateway.WebClient.Controllers
{
	[ApiController]
	[Route("production")]
	public class ProdutionController : Controller
	{
		private readonly IProductionProxy _productionProxy;
		public ProdutionController(IProductionProxy productionProxy)
		{
			_productionProxy = productionProxy;
		}

		[HttpGet("GetProducts")]
		public async Task<List<GetProduct>?> GetProducts()
		{
			return await _productionProxy.GetProducts();
		}
	}
}
