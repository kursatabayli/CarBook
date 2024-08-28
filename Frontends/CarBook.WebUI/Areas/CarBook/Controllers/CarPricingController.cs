using CarBook.Dto.CarPricingWithCarsDtos;
using CarBook.WebUI.Areas.CarBook.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CarBook.WebUI.Areas.CarBook.Controllers
{
    [Area("CarBook")]
    [Route("CarBook/[controller]")]
    public class CarPricingController : Controller
    {
        private readonly IApiCarBookService<ResultCarPricingWithCarsDto> _apiService;

        public CarPricingController(IApiCarBookService<ResultCarPricingWithCarsDto> apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Araç Fiyatları";
            ViewBag.v2 = "Paketler";
            ViewBag.url = "/CarBook/CarPricing/Index/";

            var values = await _apiService.GetListAsync("https://localhost:7278/api/CarPricings/GetCarPricingWithDetails/");
            return View(values);
        }
    }
}
