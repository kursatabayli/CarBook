using CarBook.Dto.SocialMediaDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminSocialMedia")]
    
    public class AdminSocialMediaController : Controller
    {
        private readonly IApiAdminService<ResultSocialMediaDto> _apiService;
        private readonly IApiAdminService<CreateSocialMediaDto> _createApiService;
        private readonly IApiAdminService<UpdateSocialMediaDto> _updateApiService;

        public AdminSocialMediaController(
            IApiAdminService<ResultSocialMediaDto> apiService,
            IApiAdminService<CreateSocialMediaDto> createApiService,
            IApiAdminService<UpdateSocialMediaDto> updateApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/SocialMedias/");
            return View(values);
        }

        [HttpGet]
        [Route("CreateSocialMedia")]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateSocialMedia")]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var value = await _createApiService.CreateItemAsync("https://localhost:7278/api/AdminSocialMedias/", createSocialMediaDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminSocialMedia", new { area = "Admin" }) });

            }
            return View(createSocialMediaDto);
        }

        [Route("RemoveSocialMedia/{id}")]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            await _apiService.RemoveItemAsync($"https://localhost:7278/api/AdminSocialMedias/{id}");
            return RedirectToAction("Index");

        }

        [HttpGet]
        [Route("UpdateSocialMedia/{id}")]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var value = await _updateApiService.GetItemAsync($"https://localhost:7278/api/SocialMedias/{id}");
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("UpdateSocialMedia/{id}")]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var value = await _updateApiService.UpdateItemAsync("https://localhost:7278/api/AdminSocialMedias/", updateSocialMediaDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminSocialMedia", new { area = "Admin" }) });

            }
            return View(updateSocialMediaDto);
        }
    }
}
