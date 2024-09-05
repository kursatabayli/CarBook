using CarBook.Dto.BrandDtos;
using CarBook.Dto.CarDtos;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCar")]
    public class AdminCarController : Controller
    {
        private readonly IApiAdminService<ResultCarWithBrandsDto> _apiService;
        private readonly IApiAdminService<CreateCarDto> _createApiService;
        private readonly IApiAdminService<UpdateCarDto> _updateApiService;
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(
            IApiAdminService<ResultCarWithBrandsDto> apiService,
            IApiAdminService<CreateCarDto> createApiService,
            IApiAdminService<UpdateCarDto> updateApiService,
            IHttpClientFactory httpClientFactory)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/Cars/CarsListWithBrandAndOtherFeatures");
            return View(values);
        }

        [HttpGet("CreateCar")]
        public async Task<IActionResult> CreateCar()
        {
            await _createApiService.GetEmpty();
            await LoadSelectLists();
            return View();
        }

        [HttpPost("CreateCar")]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            var value = await _createApiService.CreateItemAsync("https://localhost:7278/api/AdminCars/", createCarDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminCar", new { area = "Admin" }) });

            }
            await LoadSelectLists();
            return View(createCarDto);
        }

        [HttpDelete("RemoveCar/{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _apiService.RemoveItemAsync($"https://localhost:7278/api/AdminCars/{id}");
            return Ok();
        }

        [HttpGet("UpdateCar/{id}")]
        public async Task<IActionResult> UpdateCar(int id)
        {
            await LoadSelectLists();
            var value = await _updateApiService.GetItemAsync($"https://localhost:7278/api/Cars/{id}");
            return View(value);
        }

        [HttpPost("UpdateCar/{id}")]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            var value = await _updateApiService.UpdateItemAsync("https://localhost:7278/api/AdminCars/", updateCarDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminCar", new { area = "Admin" }) });

            }
            await LoadSelectLists();
            return View(updateCarDto);
        }

        private async Task LoadSelectLists()
        {
            var client = _httpClientFactory.CreateClient();
            var brandResponseTask = client.GetAsync("https://localhost:7278/api/Brands");
            var fuelResponseTask = client.GetAsync("https://localhost:7278/api/Cars/FeulTypes");
            var luggageResponseTask = client.GetAsync("https://localhost:7278/api/Cars/LuggageTypes");
            var transmissionResponseTask = client.GetAsync("https://localhost:7278/api/Cars/TransmissionTypes");

            await Task.WhenAll(brandResponseTask, fuelResponseTask, luggageResponseTask, transmissionResponseTask);

            var brands = await GetSelectListItemsAsync<ResultBrandDto>(
                await brandResponseTask.Result.Content.ReadAsStringAsync(),
                x => x.Name,
                x => x.BrandID.ToString()
            );
            ViewBag.BrandValues = brands;

            var fuels = await GetSelectListItemsAsync<FuelDto>(
                await fuelResponseTask.Result.Content.ReadAsStringAsync(),
                x => x.FuelType,
                x => x.CarFuelID.ToString()
            );
            ViewBag.FuelValues = fuels;

            var luggages = await GetSelectListItemsAsync<LuggageDto>(
                await luggageResponseTask.Result.Content.ReadAsStringAsync(),
                x => x.LuggageType,
                x => x.CarLuggageID.ToString()
            );
            ViewBag.LuggageValues = luggages;

            var transmissions = await GetSelectListItemsAsync<TransmissionDto>(
                await transmissionResponseTask.Result.Content.ReadAsStringAsync(),
                x => x.TransmissionType,
                x => x.CarTransmissionID.ToString()
            );
            ViewBag.TransmissionValues = transmissions;
        }

        private async Task<List<SelectListItem>> GetSelectListItemsAsync<T>(string jsonData, Func<T, string> textSelector, Func<T, string> valueSelector)
        {
            var items = JsonConvert.DeserializeObject<List<T>>(jsonData);
            return items.Select(x => new SelectListItem
            {
                Text = textSelector(x),
                Value = valueSelector(x)
            }).ToList();
        }
    }
}
