using CarBook.Dto.CarPricingWithCarsDtos;
using CarBook.Dto.LocationDtos;
using CarBook.Dto.ReservationDtos;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminReservation")]
    public class AdminReservationController : Controller
    {
        private readonly IApiAdminService<ResultReservationDto> _apiAdminService;
        private readonly IApiAdminService<ResultCarPricingWithCarsDto> _carService;
        private readonly IApiAdminService<ResultLocationDto> _locationService;

        public AdminReservationController(IApiAdminService<ResultReservationDto> apiAdminService, IApiAdminService<ResultCarPricingWithCarsDto> carService, IApiAdminService<ResultLocationDto> locationService)
        {
            _apiAdminService = apiAdminService;
            _carService = carService;
            _locationService = locationService;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiAdminService.GetListAsync("https://localhost:7278/api/AdminReservations/");

            var tasks = values.Select(async v =>
            {
                var pickUpLocation = await _apiAdminService.GetItemAsync($"https://localhost:7278/api/Locations/{v.PickUpLocationID}");
                v.PickUpLocationName = pickUpLocation.Name;

                var dropOffLocation = await _apiAdminService.GetItemAsync($"https://localhost:7278/api/Locations/{v.DropOffLocationID}");
                v.DropOffLocationName = dropOffLocation.Name;

                var carInfo = await _apiAdminService.GetItemAsync($"https://localhost:7278/api/CarPricings/GetCarPricingDayWeekMonthById/{v.CarID}");
                v.BrandAndModel = carInfo.BrandAndModel;
                
                var amount = await _apiAdminService.GetItemAsync($"https://localhost:7278/api/CarPricings/GetCarPricingDayWeekMonthById/{v.CarID}");
                v.Amount = amount.Amount*(v.DropOffDate-v.PickUpDate).Days;
            });

            await Task.WhenAll(tasks);

            return View(values);
        }
    }
}
