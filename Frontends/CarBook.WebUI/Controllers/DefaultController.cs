using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace CarBook.WebUI.Areas.Default.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public IActionResult ReservationInfos(string reservationTime, string returnTime, string reservationDate, string returnDate, string pickUpLocation, string dropOffLocation)
        {
            return RedirectToAction("Index", "RentACarList", new { reservationTime, returnTime, reservationDate, returnDate, pickUpLocation, dropOffLocation });
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var locationResponse = await client.GetAsync("https://localhost:7278/api/Locations");
            var locationJson = await locationResponse.Content.ReadAsStringAsync();
            var locations = JsonConvert.DeserializeObject<List<ResultLocationDto>>(locationJson);

            var locationValues = locations.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.LocationID.ToString()
            }).ToList();

            ViewBag.LocationValues = locationValues;

            return View();
        }
    }
}
