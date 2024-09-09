using CarBook.Dto.TagCloudDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using CarBook.WebUI.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminTagCloud")]
    
    public class AdminTagCloudController : Controller
    {
        private readonly IApiService<ResultTagCloudDto> _apiService;
        private readonly IApiService<CreateTagCloudDto> _createApiService;
        private readonly IApiService<UpdateTagCloudDto> _updateApiService;

        public AdminTagCloudController(
            IApiService<ResultTagCloudDto> apiService,
            IApiService<CreateTagCloudDto> createApiService,
            IApiService<UpdateTagCloudDto> updateApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("TagClouds/");
            return View(values);
        }

        [HttpGet("CreateTagCloud")]
        public async Task<IActionResult> CreateTagCloud()
        {
            await _createApiService.GetEmpty();
            return View();
        }

        [HttpPost("CreateTagCloud")]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudDto createTagCloudDto)
        {
            var value = await _createApiService.CreateItemAsync("AdminTagClouds/", createTagCloudDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminTagCloud", new { area = "Admin" }) });

            }
            return View(createTagCloudDto);
        }

        [HttpDelete("RemoveTagCloud/{id}")]
        public async Task<IActionResult> RemoveTagCloud(int id)
        {
            await _apiService.RemoveItemAsync($"AdminTagClouds/{id}");
            return Ok();

        }

        [HttpGet("UpdateTagCloud/{id}")]
        public async Task<IActionResult> UpdateTagCloud(int id)
        {
            var value = await _updateApiService.GetItemAsync($"TagClouds/{id}");
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("Index");
        }

        [HttpPost("UpdateTagCloud/{id}")]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudDto updateTagCloudDto)
        {
            var value = await _updateApiService.UpdateItemAsync("AdminTagClouds/", updateTagCloudDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminTagCloud", new { area = "Admin" }) });

            }
            return View(updateTagCloudDto);
        }
    }
}
