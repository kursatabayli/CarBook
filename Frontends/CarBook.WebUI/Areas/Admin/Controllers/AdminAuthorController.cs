using CarBook.Dto.AuthorDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminAuthor")]
    
    public class AdminAuthorController : Controller
    {
        private readonly IApiAdminService<ResultAuthorDto> _apiService;
        private readonly IApiAdminService<CreateAuthorDto> _createApiService;
        private readonly IApiAdminService<UpdateAuthorDto> _updateApiService;

        public AdminAuthorController(
            IApiAdminService<ResultAuthorDto> apiService,
            IApiAdminService<CreateAuthorDto> createApiService,
            IApiAdminService<UpdateAuthorDto> updateApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/Authors");
            return View(values);
        }

        [HttpGet]
        [Route("CreateAuthor")]
        public IActionResult CreateAuthor()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateAuthor")]
        public async Task<IActionResult> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var value = await _createApiService.CreateItemAsync("https://localhost:7278/api/AdminAuthors/", createAuthorDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminAuthor", new { area = "Admin" }) });
            }
            return View(createAuthorDto);
        }

        [Route("RemoveAuthor/{id}")]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            var value = await _apiService.RemoveItemAsync($"https://localhost:7278/api/AdminAuthors/{id}");
            return RedirectToAction("Index");

        }

        [HttpGet]
        [Route("UpdateAuthor/{id}")]
        public async Task<IActionResult> UpdateAuthor(int id)
        {
            var value = await _updateApiService.GetItemAsync($"https://localhost:7278/api/Authors/{id}");
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("UpdateAuthor/{id}")]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto updateAuthorDto)
        {
            var value = await _updateApiService.UpdateItemAsync("https://localhost:7278/api/AdminAuthors/", updateAuthorDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminAuthor", new { area = "Admin" }) });
            }
            return View(updateAuthorDto);
        }
    }
}
