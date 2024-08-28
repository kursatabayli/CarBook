using CarBook.Dto.RentACarDtos;
using CarBook.WebUI.Areas.CarBook.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web;

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
            ViewBag.pickUpLocation = pickUpLocation;
            ViewBag.dropOffLocation = dropOffLocation;
            ViewBag.reservationDate = reservationDate;
            ViewBag.reservationTime = reservationTime;
            ViewBag.returnDate = returnDate;
            ViewBag.returnTime = returnTime;

            string formattedPickUpDate = DateTime.Parse(reservationDate).ToString("MM.dd.yyyy");
            string formattedDropOffDate = DateTime.Parse(returnDate).ToString("MM.dd.yyyy");

            string pickUpDateEncoded = HttpUtility.UrlEncode(formattedPickUpDate);
            string dropOffDateEncoded = HttpUtility.UrlEncode(formattedDropOffDate);
            string pickUpTimeEncoded = HttpUtility.UrlEncode(reservationTime);
            string dropOffTimeEncoded = HttpUtility.UrlEncode(returnTime);
            string locationIDEncoded = HttpUtility.UrlEncode(pickUpLocation.ToString());

            var apiUrl = $"https://localhost:7278/api/Reservations/GetAvailableCars?pickUpDate={pickUpDateEncoded}&dropOffDate={dropOffDateEncoded}&pickUpTime={pickUpTimeEncoded}&dropOffTime={dropOffTimeEncoded}&locationID={locationIDEncoded}";


            var values = await _apiService.GetListAsync(apiUrl);

            return View(values);
        }

        [HttpGet("PrepareReservation")]
        public IActionResult PrepareReservation(int carId, string reservationTime, string returnTime, string reservationDate, string returnDate, int pickUpLocation, int dropOffLocation)
        {
            // TempData'ya değerleri kaydediyoruz
            TempData["reservationTime"] = reservationTime;
            TempData["returnTime"] = returnTime;
            TempData["reservationDate"] = reservationDate;
            TempData["returnDate"] = returnDate;
            TempData["pickUpLocation"] = pickUpLocation;
            TempData["dropOffLocation"] = dropOffLocation;

            // ReservationController'a yönlendiriyoruz
            return RedirectToAction("Index", "Reservation", new { id = carId });
        }
    }
}
