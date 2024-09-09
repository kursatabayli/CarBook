using CarBook.Dto.CarPricingWithCarsDtos;
using CarBook.Dto.LocationDtos;
using CarBook.Dto.ReservationDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminReservation")]
    public class AdminReservationController : Controller
    {
        private readonly IApiService<ResultReservationDto> _apiAdminService;
        private readonly IApiService<ResultCarPricingWithCarsDto> _carService;
        private readonly IApiService<ResultLocationDto> _locationService;

        public AdminReservationController(IApiService<ResultReservationDto> apiAdminService, IApiService<ResultCarPricingWithCarsDto> carService, IApiService<ResultLocationDto> locationService)
        {
            _apiAdminService = apiAdminService;
            _carService = carService;
            _locationService = locationService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiAdminService.GetListAsync("AdminReservations/");

            var tasks = values.Select(async v =>
            {
                var pickUpLocation = await _apiAdminService.GetItemAsync($"Locations/{v.PickUpLocationID}");
                v.PickUpLocationName = pickUpLocation.Name;

                var dropOffLocation = await _apiAdminService.GetItemAsync($"Locations/{v.DropOffLocationID}");
                v.DropOffLocationName = dropOffLocation.Name;

                var carInfo = await _apiAdminService.GetItemAsync($"CarPricings/GetCarPricingsByCarId/{v.CarID}");
                v.BrandAndModel = carInfo.BrandAndModel;
                
                var amount = await _apiAdminService.GetItemAsync($"CarPricings/GetCarPricingsByCarId/{v.CarID}");
                v.Amount = amount.Amount*(v.DropOffDate-v.PickUpDate).Days;
            });

            await Task.WhenAll(tasks);

            return View(values);
        }
    }
}
