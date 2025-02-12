using Api.Gateway.Models;
using Api.Gateway.Proxies;
using Api.Gateway.Proxies.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Gateway.WebClient.Controllers
{
	[ApiController]
	[Route("hr")]
	public class HRController : Controller
	{
		private readonly IHRProxy _HRProxy;
		public HRController(IHRProxy HRProxy)
		{
			_HRProxy = HRProxy;
		}

		[HttpGet("GetEmployees")]
		public async Task<List<GetEmployee>?> GetEmployees()
		{
			return await _HRProxy.GetEmployees();
		}
	}
}
