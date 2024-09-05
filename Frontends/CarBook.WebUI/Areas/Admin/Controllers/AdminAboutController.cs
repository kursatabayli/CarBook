using CarBook.Dto.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminAbout")]
    
    public class AdminAboutController : Controller
    {
        private readonly IApiAdminService<ResultAboutDto> _apiService;
        private readonly IApiAdminService<CreateAboutDto> _createApiService;
        private readonly IApiAdminService<UpdateAboutDto> _updateApiService;

        public AdminAboutController(
            IApiAdminService<ResultAboutDto> apiService,
            IApiAdminService<CreateAboutDto> createApiService,
            IApiAdminService<UpdateAboutDto> updateApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/Abouts/");
            return View(values);
        }

        [HttpGet]
        [Route("CreateAbout")]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateAbout")]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            var value = await _createApiService.CreateItemAsync("https://localhost:7278/api/AdminAbouts/", createAboutDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminAbout", new {area = "Admin"}) });
            }
            return View();
        }

        [Route("RemoveAbout/{id}")]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            await _apiService.RemoveItemAsync($"https://localhost:7278/api/AdminAbouts/{id}");
            return RedirectToAction("Index");

        }

        [HttpGet]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var value = await _updateApiService.GetItemAsync($"https://localhost:7278/api/Abouts/{id}");
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var value = await _updateApiService.UpdateItemAsync("https://localhost:7278/api/AdminAbouts/", updateAboutDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminAbout", new { area = "Admin" }) });
            }
            return View(updateAboutDto);
        }
    }
}
