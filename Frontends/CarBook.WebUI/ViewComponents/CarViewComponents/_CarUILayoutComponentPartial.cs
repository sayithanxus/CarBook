using CarBook.Dto.CarDto;
using CarBook.Dto.CarPricingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CarViewComponents
{
	public class _CarUILayoutComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _CarUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7173/api/CarPricings");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
