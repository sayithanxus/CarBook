using CarBook.Dto.CarFeatureDtos;
using CarBook.Dto.FeatureDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index/{id}")]
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7173/api/CarFeatures?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDto)
        {

            foreach (var item in resultCarFeatureByCarIdDto)
            {
                if (item.Available)
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:7173/api/CarFeatures/CarFeatureChangeAvailableToTrue?id=" + item.CarFeatureID);

                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:7173/api/CarFeatures/CarFeatureChangeAvailableToFalse?id=" + item.CarFeatureID);
                }
            }
            return RedirectToAction("Index", "AdminCar");
        }

        [Route("CreateFeatureByCarId/{id}")]
        [HttpGet]
        public async Task<IActionResult> CreateFeatureByCarId(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7173/api/CarFeatures/GetFeaturesNotInCar?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                List<ResultFeatureDto> features = null;
                try
                {
                    features = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                }
                catch (Exception ex)
                {
                    // Log the error for debugging
                    Console.WriteLine($"Deserialization error: {ex.Message}");
                    features = new List<ResultFeatureDto>(); 
                }

                if (features == null)
                {
                    features = new List<ResultFeatureDto>(); 
                }

                // Available özelliğini varsayılan olarak false yap
                foreach (var feature in features)
                {
                    feature.Available = false;
                }

                var createCarFeature = new CreateCarFeatureDto
                {
                    CarID = id // Set the CarId from the route parameter
                };

                var viewModel = new CarFeatureViewModel
                {
                    Features = features,
                    CreateCarFeature = createCarFeature
                };

                return View(viewModel);
            }
            return View();
        }
        [Route("CreateFeatureByCarId/{id}")]
        [HttpPost]
        public async Task<IActionResult> CreateFeatureByCarId(CarFeatureViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();

                // Available özelliği true olan özellikleri seç
                var selectedFeatures = viewModel.Features
                    .Where(f => f.Available)
                    .Select(f => new CreateCarFeatureDto
                    {
                        CarID = viewModel.CreateCarFeature.CarID,
                        FeatureID = f.FeatureID,
                        Available=true
                    })
                    .ToList();

                var jsonData = JsonConvert.SerializeObject(selectedFeatures);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var responseMessage = await client.PostAsync("https://localhost:7173/api/CarFeatures", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "AdminCar");
                }
            }

            // ModelState geçerli değilse, viewModel'i tekrar göster
            return View(viewModel);
        }
    }
}
