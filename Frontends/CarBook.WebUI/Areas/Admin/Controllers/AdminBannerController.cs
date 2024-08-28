using CarBook.Dto.BannerDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/AdminBanner")]
    
    public class AdminBannerController : Controller
    {

        private readonly IApiAdminService<ResultBannerDto> _apiService;
        private readonly IApiAdminService<CreateBannerDto> _createApiService; 
        private readonly IApiAdminService<UpdateBannerDto> _updateApiService;

        public AdminBannerController(IApiAdminService<ResultBannerDto> apiService, IApiAdminService<CreateBannerDto> createApiService, IApiAdminService<UpdateBannerDto> updateApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/Banners/");
            return View(values);
        }

        [HttpGet]
        [Route("CreateBanner")]
        public IActionResult CreateBanner()
        {

            return View();
        }
        [HttpPost]
        [Route("CreateBanner")]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            var value = await _createApiService.CreateItemAsync("https://localhost:7278/api/AdminBanners/", createBannerDto);
            return RedirectToAction("Index");

        }

        [Route("RemoveBanner/{id}")]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            var value = await _apiService.RemoveItemAsync($"https://localhost:7278/api/AdminBanners/{id}");
            if (value)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
       
        [HttpGet]
        [Route("UpdateBanner/{id}")]
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var value = await _updateApiService.GetItemAsync($"https://localhost:7278/api/Banners/{id}");
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        [Route("UpdateBanner/{id}")]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            var value = await _updateApiService.UpdateItemAsync("https://localhost:7278/api/AdminBanners/", updateBannerDto);
            if (value)
            {
                return RedirectToAction("Index");
            }
            return View(updateBannerDto);
        }
    }
}
