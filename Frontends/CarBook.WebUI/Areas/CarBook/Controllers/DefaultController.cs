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
        private readonly IApiCarBookService<ResultLocationDto> _apiService;

        public DefaultController(IApiCarBookService<ResultLocationDto> apiService)
        {
            _apiService = apiService;
        }

        [HttpPost("ReservationInfos")]
        public IActionResult ReservationInfos(string reservationTime, string returnTime, string reservationDate, string returnDate, string pickUpLocation, string dropOffLocation)
        {
            return RedirectToAction("Index", "RentACarList", new { reservationTime, returnTime, reservationDate, returnDate, pickUpLocation, dropOffLocation });
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var locationValues = await _apiService.GetListAsync("https://localhost:7278/api/Locations");

            var location = locationValues.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.LocationID.ToString()
            }).ToList();

            ViewBag.LocationValues = location;
            return View();
        }
    }
}
