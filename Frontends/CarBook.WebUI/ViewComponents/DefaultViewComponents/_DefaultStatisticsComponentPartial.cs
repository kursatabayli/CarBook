using CarBook.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var carCountResponse = await client.GetAsync("https://localhost:7278/api/Statistics/GetCarCount");
            if (carCountResponse.IsSuccessStatusCode)
            {
                var jsonData = await carCountResponse.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                ViewBag.CarCount = values.CarCount;
            }

            var locationCountResponse = await client.GetAsync("https://localhost:7278/api/Statistics/GetLocationCount");
            if (locationCountResponse.IsSuccessStatusCode)
            {
                var jsonData = await locationCountResponse.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                ViewBag.LocationCount = values.LocationCount;
            }

            var testimonialsCountResponse = await client.GetAsync("https://localhost:7278/api/Statistics/GetTestimonialsCount");
            if (testimonialsCountResponse.IsSuccessStatusCode)
            {
                var jsonData = await testimonialsCountResponse.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                ViewBag.TestimonialsCount = values.TestimonialsCount;
            }

            return View();
        }
    }
}
