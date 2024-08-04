using CarBook.Dto.AboutDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.AboutViewComponents
{
	public class _BecomeADriverUILayoutComponentPartial : ViewComponent
	{	

		public IViewComponentResult Invoke()
		{			
			return View();
		}
	}
}
