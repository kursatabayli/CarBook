using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.CarBook.Controllers
{
    [Area("CarBook")]
    [Route("CarBook/About")]
    public class AboutController : Controller
    {
        [HttpGet("Index")]
        public IActionResult Index()
        {
            ViewBag.v1 = "Hakkımızda";
            ViewBag.v2 = "Hakkımızda";
            ViewBag.url = "/CarBook/About/Index/";
            return View();
        }
    }
}
