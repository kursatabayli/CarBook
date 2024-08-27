using CarBook.Dto.CarPricingWithCarsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CarBook.WebUI.Areas.Default.Controllers
{
    public class CarPricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarPricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Araç Fiyatları";
            ViewBag.v2 = "Paketler";
            ViewBag.url = "/CarPricing/Index/";
            var client = _httpClientFactory.CreateClient();
            var priceResponse = await client.GetAsync($"https://localhost:7278/api/CarPricings/GetCarPricingWithDetails/");
            if (priceResponse.IsSuccessStatusCode)
            {
                var responseData = await priceResponse.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarsDto>>(responseData);
                return View(values);
            }

            return View();

        }
    }
}
