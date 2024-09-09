using CarBook.Dto.CarPricingWithCarsDtos;
using CarBook.WebUI.Services.Interfaces;
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
        private readonly IApiService<ResultCarPricingWithCarsDto> _apiService;

        public CarPricingController(IApiService<ResultCarPricingWithCarsDto> apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Araç Fiyatları";
            ViewBag.v2 = "Paketler";
            ViewBag.url = "/CarBook/CarPricing/Index/";

            var values = await _apiService.GetListAsync("CarPricings/GetCarPricingWithDetails/");
            return View(values);
        }
    }
}
