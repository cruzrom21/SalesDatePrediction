using Api.Gateway.Models;
using Api.Gateway.Proxies.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Api.Gateway.Proxies
{
	public class SalesProxy : ISalesProxy
	{
		private readonly ApiUrls _apiUrls;
		private readonly HttpClient _httpClient;

		public SalesProxy(IOptions<ApiUrls> apiUrls, HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
		{
			_apiUrls = apiUrls.Value;
			_httpClient = httpClient;
		}

		public async Task<List<GetSalesDatePrediction>?> GetSalesDatePrediction()
		{
			var request = await _httpClient.GetAsync(_apiUrls.SalesUrl + "sales/GetSalesDatePrediction");
			request.EnsureSuccessStatusCode();

			return JsonSerializer.Deserialize<List<GetSalesDatePrediction>>(
				await request.Content.ReadAsStringAsync(),
				new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				}
			);
		}
		public async Task<List<GetSalesDatePrediction>?> GetSalesDatePredictionFilter(string CustName)
		{
			var request = await _httpClient.GetAsync(_apiUrls.SalesUrl + "sales/GetSalesDatePredictionFilter?CustName=" + CustName);
			request.EnsureSuccessStatusCode();

			return JsonSerializer.Deserialize<List<GetSalesDatePrediction>>(
				await request.Content.ReadAsStringAsync(),
				new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				}
			);
		}

		public async Task<List<GetClientOrder>?> GetClientOrder(int custid)
		{
			var request = await _httpClient.GetAsync(_apiUrls.SalesUrl + "sales/GetClientOrders?custid=" + custid);
			request.EnsureSuccessStatusCode();

			return JsonSerializer.Deserialize<List<GetClientOrder>>(
				await request.Content.ReadAsStringAsync(),
				new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				}
			);
		}

		public async Task<bool> AddNewOrder(NewOrderDTO newOrder)
		{
			var json = JsonSerializer.Serialize(newOrder);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var request = await _httpClient.PostAsync(_apiUrls.SalesUrl + "sales/AddNewOrder", content);
			request.EnsureSuccessStatusCode();

			return JsonSerializer.Deserialize<bool>(
				await request.Content.ReadAsStringAsync(),
				new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				}
			);
		}

		public async Task<List<GetShipper>?> GetShippers()
		{
			var request = await _httpClient.GetAsync(_apiUrls.SalesUrl + "sales/GetShippers");
			request.EnsureSuccessStatusCode();

			return JsonSerializer.Deserialize<List<GetShipper>>(
				await request.Content.ReadAsStringAsync(),
				new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				}
			);
		}
	}
}
