using CarBook.Dto.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminFeature")]
    
    public class AdminFeatureController : Controller
    {
        private readonly IApiAdminService<ResultFeatureDto> _apiService;
        private readonly IApiAdminService<CreateFeatureDto> _createApiService;
        private readonly IApiAdminService<UpdateFeatureDto> _updateApiService;

        public AdminFeatureController(IApiAdminService<ResultFeatureDto> apiService, IApiAdminService<CreateFeatureDto> createApiService, IApiAdminService<UpdateFeatureDto> updateApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/Features");
            return View(values);
        }

        [HttpGet]
        [Route("CreateFeature")]
        public IActionResult CreateFeature()
        {

            return View();
        }

        [HttpPost]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var value = await _createApiService.CreateItemAsync("https://localhost:7278/api/AdminFeatures/", createFeatureDto);
            if (value)
            {
                return RedirectToAction("Index");
            }
            return View(createFeatureDto);
        }

        [Route("RemoveFeature/{id}")]
        public async Task<IActionResult> RemoveFeature(int id)
        {
            await _apiService.RemoveItemAsync($"https://localhost:7278/api/AdminFeatures/{id}");
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("UpdateFeature/{id}")]

        public async Task<IActionResult> UpdateFeature(int id)
        {
            var value = await _updateApiService.GetItemAsync($"https://localhost:7278/api/Features/{id}");
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("UpdateFeature/{id}")]

        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var value = await _updateApiService.UpdateItemAsync("https://localhost:7278/api/AdminFeatures/", updateFeatureDto);
            if (value)
            {
                return RedirectToAction("Index");
            }
            return View(updateFeatureDto);
        }
    }
}
