using CarBook.Dto.CarPricingWithCarsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
	public class CarController : Controller
	{

		private readonly IHttpClientFactory _httpClientFactory;

		public CarController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
            ViewBag.v1 = "Arabalar";
            ViewBag.v2 = "Filomuz";
            var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7278/api/CarPricings/GetCarPricingWithCarsList");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarsDto>>(jsonData);
				return View(values);
			}
			return View();
		}

	}

}
