using CarBook.Dto.CarDtos;
using CarBook.Dto.LocationDtos;
using CarBook.Dto.ReservationDtos;
using CarBook.WebUI.Areas.CarBook.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Web;

namespace CarBook.WebUI.Areas.CarBook.Controllers
{
    [Area("CarBook")]
    [Route("CarBook/Reservation")]
    public class ReservationController : Controller
    {
        private readonly IApiCarBookService<ResultCarWithBrandsDto> _carApiService;
        private readonly IApiCarBookService<ResultLocationDto> _locationApiService;
        private readonly IApiCarBookService<CreateReservationDto> _createApiService;

        public ReservationController(IApiCarBookService<ResultCarWithBrandsDto> carApiService, IApiCarBookService<CreateReservationDto> createApiService, IApiCarBookService<ResultLocationDto> locationApiService)
        {
            _carApiService = carApiService;
            _createApiService = createApiService;
            _locationApiService = locationApiService;
        }

        [HttpGet("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            string reservationTime = TempData["reservationTime"]?.ToString();
            string returnTime = TempData["returnTime"]?.ToString();
            string reservationDate = TempData["reservationDate"]?.ToString();
            string returnDate = TempData["returnDate"]?.ToString();
            int pickUpLocation = int.Parse(TempData["pickUpLocation"]?.ToString());
            int dropOffLocation = int.Parse(TempData["dropOffLocation"]?.ToString());

            ViewBag.PickUpDate = reservationDate;
            ViewBag.DropOffDate = returnDate;
            ViewBag.PickUpTime = reservationTime;
            ViewBag.DropOffTime = returnTime;
            ViewBag.PickUpLocationID = pickUpLocation;
            ViewBag.DropOffLocationID = dropOffLocation;

            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = "Araç Rezervasyon Formu";
            ViewBag.v3 = id;

            var carValue = await _carApiService.GetItemAsync($"https://localhost:7278/api/Cars/GetCarDetailsById/{id}");
            ViewBag.CarBrand = carValue.BrandName;
            ViewBag.CarModel = carValue.Model;
            
            var pickUp = await _locationApiService.GetItemAsync($"https://localhost:7278/api/Locations/{pickUpLocation}");
            ViewBag.PickUpLocation = pickUp.Name;
            
            var dropOff = await _locationApiService.GetItemAsync($"https://localhost:7278/api/Locations/{dropOffLocation}");
            ViewBag.DropOffLocation = dropOff.Name;

            return View();
        }

        [HttpPost("Index")]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            var value = await _createApiService.CreateItemAsync("https://localhost:7278/api/Reservations/", createReservationDto);

            if (value)
            {

                return RedirectToAction("Index", "Default", new { area = "CarBook" });
            }
            return View();
        }
    }
}
