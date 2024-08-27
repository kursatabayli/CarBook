using CarBook.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Default.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
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

            var client = _httpClientFactory.CreateClient();
            var locationResponse = await client.GetAsync($"https://localhost:7278/api/RentACars?LocationID={locationID}&Available=true");
            if (locationResponse.IsSuccessStatusCode)
            {
                var locationData = await locationResponse.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(locationData);
                return View(values);
            }
            return View();
        }
    }
}
