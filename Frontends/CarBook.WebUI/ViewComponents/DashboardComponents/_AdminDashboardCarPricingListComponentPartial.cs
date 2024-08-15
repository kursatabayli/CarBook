using CarBook.Dto.CarPricingWithCarsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardCarPricingListComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardCarPricingListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IViewComponentResult> Index()
        {
            ViewBag.v1 = "Araç Fiyatları";
            ViewBag.v2 = "Paketler";
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
