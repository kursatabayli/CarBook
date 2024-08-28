using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Site.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
