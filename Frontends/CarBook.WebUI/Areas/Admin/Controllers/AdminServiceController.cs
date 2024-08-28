using CarBook.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminService")]
    
    public class AdminServiceController : Controller
    {
        private readonly IApiAdminService<ResultServiceDto> _apiService;
        private readonly IApiAdminService<CreateServiceDto> _createApiService;
        private readonly IApiAdminService<UpdateServiceDto> _updateApiService;

        public AdminServiceController(
            IApiAdminService<ResultServiceDto> apiService,
            IApiAdminService<CreateServiceDto> createApiService,
            IApiAdminService<UpdateServiceDto> updateApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/Services/");
            return View(values);
        }

        [HttpGet]
        [Route("CreateService")]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateService")]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            var value = await _createApiService.CreateItemAsync("https://localhost:7278/api/AdminServices/", createServiceDto);
            if (value)
            {
                return RedirectToAction("Index");
            }
            return View(createServiceDto);
        }

        [Route("RemoveService/{id}")]
        public async Task<IActionResult> RemoveService(int id)
        {
            await _apiService.RemoveItemAsync($"https://localhost:7278/api/AdminServices/{id}");
            return RedirectToAction("Index");

        }

        [HttpGet]
        [Route("UpdateService/{id}")]
        public async Task<IActionResult> UpdateService(int id)
        {
            var value = await _updateApiService.GetItemAsync($"https://localhost:7278/api/Services/{id}");
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("UpdateService/{id}")]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            var value = await _updateApiService.UpdateItemAsync("https://localhost:7278/api/AdminServices/", updateServiceDto);
            if (value)
            {
                return RedirectToAction("Index");
            }
            return View(updateServiceDto);
        }
    }
}
