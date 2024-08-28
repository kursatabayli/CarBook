using CarBook.Dto.CarPricingWithCarsDtos;
using CarBook.WebUI.Areas.CarBook.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.CarBook.Controllers
{
    [Area("CarBook")]
    [Route("CarBook/[controller]")]
    public class CarController : Controller
    {
        private readonly IApiCarBookService<ResultCarPricingWithCarsDto> _apiService;

        public CarController(IApiCarBookService<ResultCarPricingWithCarsDto> apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Arabalar";
            ViewBag.v2 = "Filomuz";
            ViewBag.url = "/CarBook/Car/Index/";
            var values = await _apiService.GetListAsync("https://localhost:7278/api/CarPricings/GetCarPricingWithDetails");
            return View(values);
        }

        [HttpGet("CarDetail/{id}")]
        public async Task<IActionResult> CarDetail(int id)
        {
            ViewBag.v1 = "Arabalar";
            ViewBag.v2 = "Araç Detayları";
            ViewBag.url = "/CarBook/Car/Index/";
            ViewBag.carid = id;
            return View();
        }
    }
}
