using CarBook.Dto.BrandDtos;
using CarBook.Dto.CarDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCar")]
    public class AdminCarController : Controller
    {
        private readonly IApiService<ResultCarWithBrandsDto> _apiService;
        private readonly IApiService<CreateCarDto> _createApiService;
        private readonly IApiService<UpdateCarDto> _updateApiService;
        private readonly IApiService<ResultBrandDto> _brandApiService;
        private readonly IApiService<FuelDto> _fuelApiService;
        private readonly IApiService<LuggageDto> _luggageApiService;
        private readonly IApiService<TransmissionDto> _transmissionApiService;

        public AdminCarController(
            IApiService<ResultCarWithBrandsDto> apiService,
            IApiService<CreateCarDto> createApiService,
            IApiService<UpdateCarDto> updateApiService,
            IApiService<ResultBrandDto> brandApiService,
            IApiService<FuelDto> fuelApiService,
            IApiService<LuggageDto> luggageApiService,
            IApiService<TransmissionDto> transmissionApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
            _brandApiService = brandApiService;
            _fuelApiService = fuelApiService;
            _luggageApiService = luggageApiService;
            _transmissionApiService = transmissionApiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("Cars/CarsListWithBrandAndOtherFeatures");
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
            var value = await _createApiService.CreateItemAsync("AdminCars/", createCarDto);
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
            await _apiService.RemoveItemAsync($"AdminCars/{id}");
            return Ok();
        }

        [HttpGet("UpdateCar/{id}")]
        public async Task<IActionResult> UpdateCar(int id)
        {
            await LoadSelectLists();
            var value = await _updateApiService.GetItemAsync($"Cars/{id}");
            return View(value);
        }

        [HttpPost("UpdateCar/{id}")]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            var value = await _updateApiService.UpdateItemAsync("AdminCars/", updateCarDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminCar", new { area = "Admin" }) });

            }
            await LoadSelectLists();
            return View(updateCarDto);
        }

        private async Task LoadSelectLists()
        {
            var brandTask = _brandApiService.GetListAsync("Brands/");
            var fuelTask = _fuelApiService.GetListAsync("Cars/FeulTypes/");
            var luggageTask = _luggageApiService.GetListAsync("Cars/LuggageTypes/");
            var transmissionTask = _transmissionApiService.GetListAsync("Cars/TransmissionTypes/");

            await Task.WhenAll(brandTask, fuelTask, luggageTask, transmissionTask);

            ViewBag.BrandValues = brandTask.Result.Select(x => new SelectListItem { Text = x.Name, Value = x.BrandID.ToString() }).ToList();
            ViewBag.FuelValues = fuelTask.Result.Select(x => new SelectListItem { Text = x.FuelType, Value = x.CarFuelID.ToString() }).ToList();
            ViewBag.LuggageValues = luggageTask.Result.Select(x => new SelectListItem { Text = x.LuggageType, Value = x.CarLuggageID.ToString() }).ToList();
            ViewBag.TransmissionValues = transmissionTask.Result.Select(x => new SelectListItem { Text = x.TransmissionType, Value = x.CarTransmissionID.ToString() }).ToList();
        }
    }
}
