using CarBook.Dto.BrandDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminBrand")]
    
    public class AdminBrandController : Controller
    {
        private readonly IApiAdminService<ResultBrandDto> _apiService;
        private readonly IApiAdminService<CreateBrandDto> _createApiService;
        private readonly IApiAdminService<UpdateBrandDto> _updateApiService;

        public AdminBrandController(
            IApiAdminService<ResultBrandDto> apiService,
            IApiAdminService<CreateBrandDto> createApiService,
            IApiAdminService<UpdateBrandDto> updateApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/Brands/");
            return View(values);
        }

        [HttpGet]
        [Route("CreateBrand")]
        public IActionResult CreateBrand()
        {

            return View();
        }

        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            var value = await _createApiService.CreateItemAsync("https://localhost:7278/api/AdminBrands/", createBrandDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminBrand", new { area = "Admin" }) });

            }
            return View(createBrandDto);
        }

        [Route("RemoveBrand/{id}")]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            var value = await _apiService.RemoveItemAsync($"https://localhost:7278/api/AdminBrands/{id}");
            return RedirectToAction("Index");

        }

        [HttpGet]
        [Route("UpdateBrand/{id}")]
        public async Task<IActionResult> UpdateBrand(int id)
        {
            var value = await _updateApiService.GetItemAsync($"https://localhost:7278/api/Brands/{id}");
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("UpdateBrand/{id}")]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            var value = await _updateApiService.UpdateItemAsync("https://localhost:7278/api/AdminBrands/", updateBrandDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminBrand", new { area = "Admin" }) });

            }
            return View(updateBrandDto);
        }
    }
}
