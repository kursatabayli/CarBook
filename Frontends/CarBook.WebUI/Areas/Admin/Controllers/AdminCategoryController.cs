using CarBook.Dto.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCategory")]
    
    public class AdminCategoryController : Controller
    {
        private readonly IApiAdminService<ResultCategoryDto> _apiService;
        private readonly IApiAdminService<CreateCategoryDto> _createApiService;
        private readonly IApiAdminService<UpdateCategoryDto> _updateApiService;

        public AdminCategoryController(
            IApiAdminService<ResultCategoryDto> apiService,
            IApiAdminService<CreateCategoryDto> createApiService,
            IApiAdminService<UpdateCategoryDto> updateApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/Categories/");
            return View(values);
        }

        [HttpGet]
        [Route("CreateCategory")]
        public IActionResult CreateCategory()
        {

            return View();
        }
        
        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var value = await _createApiService.CreateItemAsync("https://localhost:7278/api/AdminCategories/", createCategoryDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminCategory", new { area = "Admin" }) });

            }
            return View(createCategoryDto);
        }
        
        [Route("RemoveCategory/{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            var value = await _apiService.RemoveItemAsync($"https://localhost:7278/api/AdminCategories/{id}");
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var value = await _updateApiService.GetItemAsync($"https://localhost:7278/api/Categories/{id}");
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var value = await _updateApiService.UpdateItemAsync("https://localhost:7278/api/AdminCategories/", updateCategoryDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminCategory", new { area = "Admin" }) });

            }
            return View(updateCategoryDto);
        }
    }
}
