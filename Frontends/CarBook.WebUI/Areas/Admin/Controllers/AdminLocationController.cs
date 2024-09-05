using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;
using Newtonsoft.Json.Linq;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminLocation")]
    
    public class AdminLocationController : Controller
    {
        private readonly IApiAdminService<ResultLocationDto> _apiService;
        private readonly IApiAdminService<CreateLocationDto> _createApiService;
        private readonly IApiAdminService<UpdateLocationDto> _updateApiService;

        public AdminLocationController(
            IApiAdminService<ResultLocationDto> apiService,
            IApiAdminService<CreateLocationDto> createApiService,
            IApiAdminService<UpdateLocationDto> updateApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/Locations");
            return View(values);

        }

        [HttpGet("CreateLocation")]
        public async Task<IActionResult> CreateLocation()
        {
            await _createApiService.GetEmpty();
            return View();
        }

        [HttpPost("CreateLocation")]
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        {
            var value = await _createApiService.CreateItemAsync("https://localhost:7278/api/AdminLocations/", createLocationDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminLocation", new { area = "Admin" }) });

            }
            return View(createLocationDto);
        }

        [HttpDelete("RemoveLocation/{id}")]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            await _apiService.RemoveItemAsync($"https://localhost:7278/api/AdminLocations/{id}");
            return Ok();
        }

        [HttpGet("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var value = await _updateApiService.GetItemAsync($"https://localhost:7278/api/Locations/{id}");
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("Index");
        }

        [HttpPost("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            var value = await _updateApiService.UpdateItemAsync("https://localhost:7278/api/AdminLocations/", updateLocationDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminLocation", new { area = "Admin" }) });

            }
            return View(updateLocationDto);
        }
    }
}
