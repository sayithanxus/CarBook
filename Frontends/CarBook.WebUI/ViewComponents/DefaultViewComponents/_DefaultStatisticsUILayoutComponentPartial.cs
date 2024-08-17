using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
	public class _DefaultStatisticsUILayoutComponentPartial :ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
