using CarBook.Dto.CarDtos;
using CarBook.Dto.LocationDtos;
using CarBook.Dto.ReservationDtos;
using CarBook.WebUI.Areas.CarBook.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.CarBook.Controllers
{
    [Area("CarBook")]
    [Route("CarBook/[controller]")]
    public class ReservationController : Controller
    {
        private readonly IApiCarBookService<ResultCarWithBrandsDto> _carApiService;
        private readonly IApiCarBookService<ResultLocationDto> _locationApiService;
        private readonly IApiCarBookService<CreateReservationDto> _createApiService;

        public ReservationController(IApiCarBookService<ResultCarWithBrandsDto> carApiService, IApiCarBookService<ResultLocationDto> locationApiService, IApiCarBookService<CreateReservationDto> createApiService)
        {
            _carApiService = carApiService;
            _locationApiService = locationApiService;
            _createApiService = createApiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = "Araç Rezervasyon Formu";
            ViewBag.url = $"/RentACarList?pickUpLocation={id}";
            ViewBag.v3 = id;

            var carValue = await _carApiService.GetItemAsync($"https://localhost:7278/api/Cars/GetCarDetailsById/{id}");
            ViewBag.CarBrand = carValue.BrandName;
            ViewBag.CarModel = carValue.Model;

            var locationValues = await _locationApiService.GetListAsync("https://localhost:7278/api/Locations");
            var location = locationValues.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.LocationID.ToString()
            }).ToList();

            ViewBag.LocationValues = location;

            return View();
        }

        [HttpPost("Index")]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            var value = await _createApiService.CreateItemAsync("https://localhost:7278/api/Reservations/", createReservationDto);
            if (value)
            {
                return RedirectToAction("Index", "Default");
            }

            return View();
        }
    }
}
