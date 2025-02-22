﻿using CarBook.Dto.CarDto;
using CarBook.Dto.CarPricingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.Controllers
{
	public class CarController : Controller
	{
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
		{
            ViewBag.v1 = "Cars";
            ViewBag.v2 = "Choose Your Cars"; 
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
        public async Task<IActionResult> CarDetail(int id)
        {
            ViewBag.v1 = "Araç Detayları";
            ViewBag.v2 = "Aracın Teknik Aksesuar ve Özellikleri";
            ViewBag.carid = id;
            return View();
        }
    }
}
