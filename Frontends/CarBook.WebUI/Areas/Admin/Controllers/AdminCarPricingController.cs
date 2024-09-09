using CarBook.Dto.CarPricingWithCarsDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarPricing")]
    public class AdminCarPricingController : Controller
    {
        private readonly IApiService<UpdateCarPricingDto> _apiService;

        public AdminCarPricingController(IApiService<UpdateCarPricingDto> apiService)
        {
            _apiService = apiService;
        }
        
        [HttpGet("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.CarId = id;
            var value = await _apiService.GetItemAsync($"CarPricings/GetCarPricingsByCarId/{id}");
            return View(value);
        }

        [HttpPost("Index")]
        public async Task<IActionResult> Index(UpdateCarPricingDto updateCarPricingDto)
        {
            var value = await _apiService.UpdateItemAsync($"AdminCarPricings/UpdateCarPricingByCarId/", updateCarPricingDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminCar", new { area = "Admin" }) });
            }
            return View(updateCarPricingDto);
        }

    }
}
