using CarBook.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Default.Controllers
{
    public class ServiceController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.v1 = "Hizmetler";
            ViewBag.v2 = "Hizmetlerimiz";
            ViewBag.url = "/Service/Index/";
            return View();
        }
    }
}
