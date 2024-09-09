using CarBook.Dto.BannerDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using CarBook.WebUI.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/AdminBanner")]
    
    public class AdminBannerController : Controller
    {

        private readonly IApiService<ResultBannerDto> _apiService;
        private readonly IApiService<CreateBannerDto> _createApiService; 
        private readonly IApiService<UpdateBannerDto> _updateApiService;

        public AdminBannerController(IApiService<ResultBannerDto> apiService, IApiService<CreateBannerDto> createApiService, IApiService<UpdateBannerDto> updateApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("Banners/");
            return View(values);
        }

        [HttpGet("CreateBanner")]
        public async Task<IActionResult> CreateBanner()
        {
            await _createApiService.GetEmpty();
            return View();
        }

        [HttpPost("CreateBanner")]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            var value = await _createApiService.CreateItemAsync("AdminBanners/", createBannerDto);
            return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminBanner", new { area = "Admin" }) });


        }

        [HttpDelete("RemoveBanner/{id}")]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _apiService.RemoveItemAsync($"AdminBanners/{id}");
            return Ok();
        }
       
        [HttpGet]
        [Route("UpdateBanner/{id}")]
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var value = await _updateApiService.GetItemAsync($"Banners/{id}");
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
            var value = await _updateApiService.UpdateItemAsync("AdminBanners/", updateBannerDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminBanner", new { area = "Admin" }) });

            }
            return View(updateBannerDto);
        }
    }
}
