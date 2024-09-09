using CarBook.Dto.AuthorDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using CarBook.WebUI.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminAuthor")]
    
    public class AdminAuthorController : Controller
    {
        private readonly IApiService<ResultAuthorDto> _apiService;
        private readonly IApiService<CreateAuthorDto> _createApiService;
        private readonly IApiService<UpdateAuthorDto> _updateApiService;

        public AdminAuthorController(
            IApiService<ResultAuthorDto> apiService,
            IApiService<CreateAuthorDto> createApiService,
            IApiService<UpdateAuthorDto> updateApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("Authors");
            return View(values);
        }

        [HttpGet("CreateAuthor")]
        public async Task<IActionResult> CreateAuthor()
        {
            await _createApiService.GetEmpty();
            return View();
        }

        [HttpPost("CreateAuthor")]
        public async Task<IActionResult> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var value = await _createApiService.CreateItemAsync("AdminAuthors/", createAuthorDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminAuthor", new { area = "Admin" }) });
            }
            return View(createAuthorDto);
        }

        [HttpDelete("RemoveAuthor/{id}")]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            await _apiService.RemoveItemAsync($"AdminAuthors/{id}");
            return Ok();
        }

        [HttpGet("UpdateAuthor/{id}")]
        public async Task<IActionResult> UpdateAuthor(int id)
        {
            var value = await _updateApiService.GetItemAsync($"Authors/{id}");
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("Index");
        }

        [HttpPost("UpdateAuthor/{id}")]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto updateAuthorDto)
        {
            var value = await _updateApiService.UpdateItemAsync("AdminAuthors/", updateAuthorDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminAuthor", new { area = "Admin" }) });
            }
            return View(updateAuthorDto);
        }
    }
}
