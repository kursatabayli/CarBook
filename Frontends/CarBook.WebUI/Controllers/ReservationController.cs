using CarBook.Dto.CarDtos;
using CarBook.Dto.LocationDtos;
using CarBook.Dto.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CarBook.WebUI.Areas.Default.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();

            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = "Araç Rezervasyon Formu";
            ViewBag.v3 = id;

            var carResponse = await client.GetAsync($"https://localhost:7278/api/Cars/GetCarDetailsById/{id}");
            if (carResponse.IsSuccessStatusCode)
            {
                var carJson = await carResponse.Content.ReadAsStringAsync();
                var car = JsonConvert.DeserializeObject<ResultCarWithBrandsDto>(carJson);

                ViewBag.CarBrand = car.BrandName;
                ViewBag.CarModel = car.Model;
            }


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

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var reservationJson = JsonConvert.SerializeObject(createReservationDto);
            StringContent stringContent = new StringContent(reservationJson, Encoding.UTF8, "application/json");
            var reservationResponse = await client.PostAsync("https://localhost:7278/api/Reservations/", stringContent);
            if (reservationResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }

            return View();
        }

    }
}
