using Api.Gateway.Models;
using Api.Gateway.Proxies.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Api.Gateway.Proxies
{
	public class HRProxy : IHRProxy
	{
		private readonly ApiUrls _apiUrls;
		private readonly HttpClient _httpClient;

		public HRProxy(IOptions<ApiUrls> apiUrls, HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
		{
			_apiUrls = apiUrls.Value;
			_httpClient = httpClient;
		}

		public async Task<List<GetEmployee>?> GetEmployees()
		{
			var request = await _httpClient.GetAsync(_apiUrls.HRUrl + "hr/GetEmployees");
			request.EnsureSuccessStatusCode();

			return JsonSerializer.Deserialize<List<GetEmployee>>(
				await request.Content.ReadAsStringAsync(),
				new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				}
			);
		}
	}
}
