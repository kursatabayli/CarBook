using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Http;



namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminDashboard")]
    
    public class AdminDashboardController : Controller
    {
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
