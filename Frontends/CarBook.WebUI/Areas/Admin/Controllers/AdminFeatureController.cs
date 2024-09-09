using CarBook.Dto.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using CarBook.WebUI.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminFeature")]
    
    public class AdminFeatureController : Controller
    {
        private readonly IApiService<ResultFeatureDto> _apiService;
        private readonly IApiService<CreateFeatureDto> _createApiService;
        private readonly IApiService<UpdateFeatureDto> _updateApiService;

        public AdminFeatureController(IApiService<ResultFeatureDto> apiService, IApiService<CreateFeatureDto> createApiService, IApiService<UpdateFeatureDto> updateApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("Features");
            return View(values);
        }

        [HttpGet("CreateFeature")]
        public async Task<IActionResult> CreateFeature()
        {

            await _createApiService.GetEmpty();
            return View();
        }

        [HttpPost("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var value = await _createApiService.CreateItemAsync("AdminFeatures/", createFeatureDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminFeature", new { area = "Admin" }) });

            }
            return View(createFeatureDto);
        }

        [HttpDelete("RemoveFeature/{id}")]
        public async Task<IActionResult> RemoveFeature(int id)
        {
            await _apiService.RemoveItemAsync($"AdminFeatures/{id}");
            return Ok();
        }

        [HttpGet("UpdateFeature/{id}")]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var value = await _updateApiService.GetItemAsync($"Features/{id}");
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("Index");
        }

        [HttpPost("UpdateFeature/{id}")]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var value = await _updateApiService.UpdateItemAsync("AdminFeatures/", updateFeatureDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminFeature", new { area = "Admin" }) });

            }
            return View(updateFeatureDto);
        }
    }
}
