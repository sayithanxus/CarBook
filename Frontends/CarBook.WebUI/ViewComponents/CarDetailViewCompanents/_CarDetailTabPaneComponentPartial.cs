using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CarDetailViewCompanents
{
    public class _CarDetailTabPaneComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            return View();
        }
    }
}
