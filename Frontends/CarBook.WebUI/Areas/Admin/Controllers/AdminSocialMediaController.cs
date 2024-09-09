using CarBook.Dto.SocialMediaDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using CarBook.WebUI.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminSocialMedia")]
    
    public class AdminSocialMediaController : Controller
    {
        private readonly IApiService<ResultSocialMediaDto> _apiService;
        private readonly IApiService<CreateSocialMediaDto> _createApiService;
        private readonly IApiService<UpdateSocialMediaDto> _updateApiService;

        public AdminSocialMediaController(
            IApiService<ResultSocialMediaDto> apiService,
            IApiService<CreateSocialMediaDto> createApiService,
            IApiService<UpdateSocialMediaDto> updateApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("SocialMedias/");
            return View(values);
        }

        [HttpGet("CreateSocialMedia")]
        public async Task<IActionResult> CreateSocialMedia()
        {
            await _createApiService.GetEmpty();
            return View();
        }

        [HttpPost("CreateSocialMedia")]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var value = await _createApiService.CreateItemAsync("AdminSocialMedias/", createSocialMediaDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminSocialMedia", new { area = "Admin" }) });

            }
            return View(createSocialMediaDto);
        }

        [HttpDelete("RemoveSocialMedia/{id}")]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            await _apiService.RemoveItemAsync($"AdminSocialMedias/{id}");
            return Ok();

        }

        [HttpGet("UpdateSocialMedia/{id}")]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var value = await _updateApiService.GetItemAsync($"SocialMedias/{id}");
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("Index");
        }

        [HttpPost("UpdateSocialMedia/{id}")]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var value = await _updateApiService.UpdateItemAsync("AdminSocialMedias/", updateSocialMediaDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminSocialMedia", new { area = "Admin" }) });

            }
            return View(updateSocialMediaDto);
        }
    }
}
