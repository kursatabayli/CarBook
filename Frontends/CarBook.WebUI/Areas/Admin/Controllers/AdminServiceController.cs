using CarBook.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;
using CarBook.WebUI.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminService")]
    
    public class AdminServiceController : Controller
    {
        private readonly IApiService<ResultServiceDto> _apiService;
        private readonly IApiService<CreateServiceDto> _createApiService;
        private readonly IApiService<UpdateServiceDto> _updateApiService;

        public AdminServiceController(
            IApiService<ResultServiceDto> apiService,
            IApiService<CreateServiceDto> createApiService,
            IApiService<UpdateServiceDto> updateApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("Services/");
            return View(values);
        }

        [HttpGet("CreateService")]
        public async Task<IActionResult> CreateService()
        {
            await _createApiService.GetEmpty();
            return View();
        }

        [HttpPost("CreateService")]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            var value = await _createApiService.CreateItemAsync("AdminServices/", createServiceDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminService", new { area = "Admin" }) });
            }
            return View(createServiceDto);
        }

        [HttpDelete("RemoveService/{id}")]
        public async Task<IActionResult> RemoveService(int id)
        {
            await _apiService.RemoveItemAsync($"AdminServices/{id}");
            return Ok();

        }

        [HttpGet("UpdateService/{id}")]
        public async Task<IActionResult> UpdateService(int id)
        {
            var value = await _updateApiService.GetItemAsync($"Services/{id}");
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("Index");
        }

        [HttpPost("UpdateService/{id}")]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            var value = await _updateApiService.UpdateItemAsync("AdminServices/", updateServiceDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminService", new { area = "Admin" }) });
            }
            return View(updateServiceDto);
        }
    }
}
