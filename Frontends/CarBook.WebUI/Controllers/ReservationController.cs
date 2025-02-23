using CarBook.Dto.CarDto;
using CarBook.Dto.LocationDto;
using CarBook.Dto.ReservationDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = "Araç Rezervasyon Formu";
            ViewBag.v3 = id;
            var client = _httpClientFactory.CreateClient();

            var carResponseMessage = await client.GetAsync($"https://localhost:7173/api/Cars/{id}");
            if (carResponseMessage.IsSuccessStatusCode)
            {
                var carJsonData = await carResponseMessage.Content.ReadAsStringAsync();
                var carValue = JsonConvert.DeserializeObject<ResultCarWithBrandDto>(carJsonData);
                CreateReservationDto dto = new CreateReservationDto();
                dto.CarID = id;
                ViewBag.car = $"{carValue.BrandName} {carValue.Model}";
                ViewBag.carImage = carValue.CoverImgUrl;

                var client1 = _httpClientFactory.CreateClient();
                var responseMessage1 = await client1.GetAsync("https://localhost:7173/api/Locations");

                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData1);
                List<SelectListItem> values3 = (from x in values1
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.LocationID.ToString()
                                                }).ToList();
                ViewBag.v = values3;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7173/api/Reservations", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
