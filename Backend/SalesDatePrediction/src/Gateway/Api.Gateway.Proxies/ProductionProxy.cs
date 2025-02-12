using Api.Gateway.Models;
using Api.Gateway.Proxies.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Api.Gateway.Proxies
{
	public class ProductionProxy : IProductionProxy
	{
		private readonly ApiUrls _apiUrls;
		private readonly HttpClient _httpClient;

		public ProductionProxy(IOptions<ApiUrls> apiUrls, HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
		{
			_apiUrls = apiUrls.Value;
			_httpClient = httpClient;
		}

		public async Task<List<GetProduct>?> GetProducts()
		{
			var request = await _httpClient.GetAsync(_apiUrls.ProductionUrl + "production/GetProducts");
			request.EnsureSuccessStatusCode();

			return JsonSerializer.Deserialize<List<GetProduct>>(
				await request.Content.ReadAsStringAsync(),
				new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				}
			);
		}
	}
}
