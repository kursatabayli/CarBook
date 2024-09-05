using CarBook.Dto.CarFeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IApiAdminService<ResultCarFeatureDetailDto> _apiService;

        public AdminCarFeatureDetailController(IApiAdminService<ResultCarFeatureDetailDto> apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var values = await _apiService.GetListAsync($"https://localhost:7278/api/CarFeatures/GetCarFeatureDetail/{id}");
            return View(values);
        }

        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id, List<ResultCarFeatureDetailDto> resultCarFeatureDetailDto)
        {
            var currentValues = await _apiService.GetListAsync($"https://localhost:7278/api/CarFeatures/GetCarFeatureDetail/{id}");

            if (currentValues != null)
            {
                foreach (var item in resultCarFeatureDetailDto)
                {
                    var currentItem = currentValues.FirstOrDefault(x => x.CarFeatureID == item.CarFeatureID);

                    if (currentItem != null && currentItem.Available != item.Available)
                    {
                        string url = item.Available
                            ? $"https://localhost:7278/api/AdminCarFeatures/MakeitTrue/{item.CarFeatureID}"
                            : $"https://localhost:7278/api/AdminCarFeatures/MakeitFalse/{item.CarFeatureID}";

                        await _apiService.GetSingleAsync(url);
                    }
                }
            }
            return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminCar", new { area = "Admin" }) });
        }
    }
}
