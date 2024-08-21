using CarBook.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardStatisticsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();


            #region statistic_1
            var responseMessage1 = await client.GetAsync("https://localhost:7278/api/Statistics/GetCarCount");
            if (responseMessage1.IsSuccessStatusCode)
            {
                int carCountRandom = random.Next(0, 101);
                var jsonData = await responseMessage1.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                ViewBag.carCount = values1.CarCount.ToString();
                ViewBag.carCountRandom =  carCountRandom;
            }
            #endregion


            #region statistic_2
            var responseMessage2 = await client.GetAsync("https://localhost:7278/api/Statistics/GetBrandCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                int brandCountRandom = random.Next(0, 101);
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                ViewBag.brandCount = values2.BrandCount.ToString();
                ViewBag.brandCountRandom = brandCountRandom;
            }
            #endregion



            #region statistic_3
            var responseMessage3 = await client.GetAsync("https://localhost:7278/api/Statistics/GetLocationCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                int locationCountRandom = random.Next(0, 101);
                var jsonData = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                ViewBag.locationCount = values3.LocationCount.ToString();
                ViewBag.locationCountRandom = locationCountRandom;
            }
            #endregion



            #region statistic_4
            var responseMessage4 = await client.GetAsync("https://localhost:7278/api/Statistics/GetDailyAverageCarRentingPrice");
            if (responseMessage4.IsSuccessStatusCode)
            {
                int d_AvgCarR_Price_Random = random.Next(0, 101);
                var jsonData = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                ViewBag.d_AvgCarR_Price = values4.D_AvgCarR_Price.ToString("0.00");
                ViewBag.d_AvgCarR_Price_Random = d_AvgCarR_Price_Random;
            }
            #endregion


            return View();
        }
    }
}
