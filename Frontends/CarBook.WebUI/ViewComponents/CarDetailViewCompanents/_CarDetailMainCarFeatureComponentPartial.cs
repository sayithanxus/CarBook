using CarBook.Dto.CarDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CarDetailViewCompanents
{
    public class _CarDetailMainCarFeatureComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _CarDetailMainCarFeatureComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            if (id > 0)
            {
                ViewBag.carid = id;
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"https://localhost:7173/api/Cars/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<ResultCarWithBrandDto>(jsonData);
                    return View(values);
                }
            }
            return View();
        }
    }
}
