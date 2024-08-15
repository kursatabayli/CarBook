using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Default.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
