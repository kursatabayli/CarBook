using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;


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

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/Locations");
            return View(values);

        }

        [HttpGet]
        [Route("CreateLocation")]
        public IActionResult CreateLocation()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateLocation")]
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        {
            var success = await _createApiService.CreateItemAsync("https://localhost:7278/api/AdminLocations/", createLocationDto);
            if (success)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminLocation", new { area = "Admin" }) });

            }
            return View(createLocationDto);
        }

        [Route("RemoveLocation/{id}")]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            var success = await _apiService.RemoveItemAsync($"https://localhost:7278/api/AdminLocations/{id}");
            if (success)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var value = await _updateApiService.GetItemAsync($"https://localhost:7278/api/Locations/{id}");
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            var success = await _updateApiService.UpdateItemAsync("https://localhost:7278/api/AdminLocations/", updateLocationDto);
            if (success)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminLocation", new { area = "Admin" }) });

            }
            return View(updateLocationDto);
        }
    }
}
