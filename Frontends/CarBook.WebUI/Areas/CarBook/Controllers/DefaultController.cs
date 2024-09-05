using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using CarBook.WebUI.Areas.CarBook.Services.Interfaces;

namespace CarBook.WebUI.Areas.CarBook.Controllers
{
    [Area("CarBook")]
    [Route("CarBook/[controller]")]
    public class DefaultController : Controller
    {

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("ReservationInfos")]
        public IActionResult ReservationInfos(string reservationTime, string returnTime, string reservationDate, string returnDate, string pickUpLocation, string dropOffLocation)
        {
            ViewBag.pickUpLocation = pickUpLocation;
            ViewBag.dropOffLocation = dropOffLocation;
            ViewBag.reservationDate = reservationDate;
            ViewBag.reservationTime = reservationTime;
            ViewBag.returnDate = returnDate;
            ViewBag.returnTime = returnTime;

            return RedirectToAction("Index", "RentACarList", new { reservationTime, returnTime, reservationDate, returnDate, pickUpLocation, dropOffLocation });
        }
    }
}
