using CarBook.Dto.CarDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
	public class CarController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
