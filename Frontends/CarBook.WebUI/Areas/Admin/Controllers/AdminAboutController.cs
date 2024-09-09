using CarBook.Dto.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;
using CarBook.WebUI.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminAbout")]
    
    public class AdminAboutController : Controller
    {
        private readonly IApiService<ResultAboutDto> _apiService;
        private readonly IApiService<CreateAboutDto> _createApiService;
        private readonly IApiService<UpdateAboutDto> _updateApiService;

        public AdminAboutController(
            IApiService<ResultAboutDto> apiService,
            IApiService<CreateAboutDto> createApiService,
            IApiService<UpdateAboutDto> updateApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("Abouts/");
            return View(values);
        }

        [HttpGet("CreateAbout")]
        public async Task<IActionResult> CreateAbout()
        {
            await _createApiService.GetEmpty();
            return View();
        }

        [HttpPost("CreateAbout")]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            var value = await _createApiService.CreateItemAsync("AdminAbouts/", createAboutDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminAbout", new {area = "Admin"}) });
            }
            return View();
        }

        [HttpDelete("RemoveAbout/{id}")]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            await _apiService.RemoveItemAsync($"AdminAbouts/{id}");
            return Ok();
        }

        [HttpGet("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var value = await _updateApiService.GetItemAsync($"Abouts/{id}");
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("Index");
        }

        [HttpPost("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var value = await _updateApiService.UpdateItemAsync("AdminAbouts/", updateAboutDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminAbout", new { area = "Admin" }) });
            }
            return View(updateAboutDto);
        }
    }
}
