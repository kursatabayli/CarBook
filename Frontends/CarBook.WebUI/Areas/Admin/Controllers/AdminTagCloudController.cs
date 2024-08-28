using CarBook.Dto.TagCloudDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminTagCloud")]
    
    public class AdminTagCloudController : Controller
    {
        private readonly IApiAdminService<ResultTagCloudDto> _apiService;
        private readonly IApiAdminService<CreateTagCloudDto> _createApiService;
        private readonly IApiAdminService<UpdateTagCloudDto> _updateApiService;

        public AdminTagCloudController(
            IApiAdminService<ResultTagCloudDto> apiService,
            IApiAdminService<CreateTagCloudDto> createApiService,
            IApiAdminService<UpdateTagCloudDto> updateApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/TagClouds/");
            return View(values);
        }

        [HttpGet]
        [Route("CreateTagCloud")]
        public IActionResult CreateTagCloud()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateTagCloud")]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudDto createTagCloudDto)
        {
            var value = await _createApiService.CreateItemAsync("https://localhost:7278/api/AdminTagClouds/", createTagCloudDto);
            if (value)
            {
                return RedirectToAction("Index");
            }
            return View(createTagCloudDto);
        }

        [Route("RemoveTagCloud/{id}")]
        public async Task<IActionResult> RemoveTagCloud(int id)
        {
            await _apiService.RemoveItemAsync($"https://localhost:7278/api/AdminTagClouds/{id}");
            return RedirectToAction("Index");

        }

        [HttpGet]
        [Route("UpdateTagCloud/{id}")]
        public async Task<IActionResult> UpdateTagCloud(int id)
        {
            var value = await _updateApiService.GetItemAsync($"https://localhost:7278/api/TagClouds/{id}");
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("UpdateTagCloud/{id}")]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudDto updateTagCloudDto)
        {
            var value = await _updateApiService.UpdateItemAsync("https://localhost:7278/api/AdminTagClouds/", updateTagCloudDto);
            if (value)
            {
                return RedirectToAction("Index");
            }
            return View(updateTagCloudDto);
        }
    }
}
