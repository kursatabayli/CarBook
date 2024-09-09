using CarBook.Dto.BrandDtos;
using CarBook.Dto.CarDtos;
using CarBook.Dto.LocationDtos;
using CarBook.Dto.RentACarDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.ViewComponents.DashboardComponents
{
    public class _AdminDashboardChart3ComponentPartial : ViewComponent
    {
        private readonly IApiService<ResultRentACarDto> _carApiService;
        private readonly IApiService<ResultLocationDto> _locationApiService;

        public _AdminDashboardChart3ComponentPartial(IApiService<ResultRentACarDto> carApiService, IApiService<ResultLocationDto> locationApiService)
        {
            _carApiService = carApiService;
            _locationApiService = locationApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var locationValue = await _locationApiService.GetListAsync("Locations/");

            var carValue = await _carApiService.GetListAsync("RentACars/rentacarbylocation");

            var locationCarCounts = carValue.GroupBy(c => c.LocationID)
                .Select(group => new
                {
                    LocationID = group.Key,
                    CarCount = group.SelectMany(c => c.CarID).Distinct().Count()
                })
                .OrderByDescending(x => x.CarCount)
                .Take(5)
                .ToList();


            var locationNames = locationValue.Where(l => locationCarCounts.Any(c => c.LocationID == l.LocationID))
                .ToDictionary(l => l.LocationID, l => l.Name);

            var chartData = locationCarCounts.Select(x => new
            {
                LocationName = locationNames.GetValueOrDefault(x.LocationID, "Unknown"),
                x.CarCount
            }).ToList();

            ViewBag.ChartData = chartData;
            ViewBag.LocationCount = locationValue.Count;

            return View();
        }
    }
}
