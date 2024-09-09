using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;
using CarBook.WebUI.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminLocation")]
    
    public class AdminLocationController : Controller
    {
        private readonly IApiService<ResultLocationDto> _apiService;
        private readonly IApiService<CreateLocationDto> _createApiService;
        private readonly IApiService<UpdateLocationDto> _updateApiService;

        public AdminLocationController(
            IApiService<ResultLocationDto> apiService,
            IApiService<CreateLocationDto> createApiService,
            IApiService<UpdateLocationDto> updateApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("Locations");
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
            var value = await _createApiService.CreateItemAsync("AdminLocations/", createLocationDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminLocation", new { area = "Admin" }) });

            }
            return View(createLocationDto);
        }

        [HttpDelete("RemoveLocation/{id}")]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            await _apiService.RemoveItemAsync($"AdminLocations/{id}");
            return Ok();
        }

        [HttpGet("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var value = await _updateApiService.GetItemAsync($"Locations/{id}");
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("Index");
        }

        [HttpPost("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            var value = await _updateApiService.UpdateItemAsync("AdminLocations/", updateLocationDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminLocation", new { area = "Admin" }) });

            }
            return View(updateLocationDto);
        }
    }
}
