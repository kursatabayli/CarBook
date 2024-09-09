using CarBook.Dto.CarFeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using CarBook.WebUI.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IApiService<ResultCarFeatureDetailDto> _apiService;

        public AdminCarFeatureDetailController(IApiService<ResultCarFeatureDetailDto> apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var values = await _apiService.GetListAsync($"CarFeatures/GetCarFeatureDetail/{id}");
            return View(values);
        }

        [HttpPost("Index/{id}")]
        public async Task<IActionResult> Index(int id, List<ResultCarFeatureDetailDto> resultCarFeatureDetailDto)
        {
            var currentValues = await _apiService.GetListAsync($"CarFeatures/GetCarFeatureDetail/{id}");

            if (currentValues != null)
            {
                foreach (var item in resultCarFeatureDetailDto)
                {
                    var currentItem = currentValues.FirstOrDefault(x => x.CarFeatureID == item.CarFeatureID);

                    if (currentItem != null && currentItem.Available != item.Available)
                    {
                        string url = item.Available
                            ? $"AdminCarFeatures/MakeitTrue/{item.CarFeatureID}"
                            : $"AdminCarFeatures/MakeitFalse/{item.CarFeatureID}";

                        await _apiService.GetSingleAsync(url);
                    }
                }
            }
            return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminCar", new { area = "Admin" }) });
        }
    }
}
