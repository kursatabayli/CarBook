using CarBook.Dto.RentACarDtos;
using CarBook.WebUI.Areas.CarBook.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.CarBook.Controllers
{
    [Area("CarBook")]
    [Route("CarBook/[controller]")]
    public class RentACarListController : Controller
    {
        private readonly IApiCarBookService<FilterRentACarDto> _apiService;

        public RentACarListController(IApiCarBookService<FilterRentACarDto> apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index(int locationID, int pickUpLocation, int dropOffLocation, string reservationDate, string reservationTime, string returnDate, string returnTime)
        {
            ViewBag.v1 = "Araç Kirala";

            locationID = pickUpLocation;

            ViewBag.pickUpLocation = pickUpLocation;
            ViewBag.dropOffLocation = dropOffLocation;
            ViewBag.reservationDate = reservationDate;
            ViewBag.reservationTime = reservationTime;
            ViewBag.returnDate = returnDate;
            ViewBag.returnTime = returnTime;

            var values = await _apiService.GetListAsync($"https://localhost:7278/api/RentACars?LocationID={locationID}&Available=true");
            return View(values);
        }
    }
}
