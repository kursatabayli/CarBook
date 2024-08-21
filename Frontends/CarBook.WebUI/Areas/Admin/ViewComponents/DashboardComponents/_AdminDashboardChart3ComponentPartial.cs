using CarBook.Dto.LocationDtos;
using CarBook.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.ViewComponents.DashboardComponents
{
    public class _AdminDashboardChart3ComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardChart3ComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var locationResponse = await client.GetAsync("https://localhost:7278/api/Locations");
            var locationJson = await locationResponse.Content.ReadAsStringAsync();
            var locations = JsonConvert.DeserializeObject<List<ResultLocationDto>>(locationJson);

            var carResponse = await client.GetAsync("https://localhost:7278/api/RentACars/rentacarbylocation");
            var carJson = await carResponse.Content.ReadAsStringAsync();
            var cars = JsonConvert.DeserializeObject<List<ResultRentACarDto>>(carJson);

            var locationCarCounts = cars.GroupBy(c => c.LocationID)
                .Select(group => new
                {
                    LocationID = group.Key,
                    CarCount = group.SelectMany(c => c.CarID).Distinct().Count()
                })
                .OrderByDescending(x => x.CarCount)
                .Take(5)
                .ToList();


            var locationNames = locations.Where(l => locationCarCounts.Any(c => c.LocationID == l.LocationID))
                .ToDictionary(l => l.LocationID, l => l.Name);

            var chartData = locationCarCounts.Select(x => new
            {
                LocationName = locationNames.GetValueOrDefault(x.LocationID, "Unknown"),
                x.CarCount
            }).ToList();

            ViewBag.ChartData = chartData;
            ViewBag.LocationCount = locations.Count;

            return View();
        }
    }
}
