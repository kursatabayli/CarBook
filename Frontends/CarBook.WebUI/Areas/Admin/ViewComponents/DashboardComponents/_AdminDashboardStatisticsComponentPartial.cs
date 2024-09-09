using CarBook.Dto.StatisticDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.ViewComponents.DashboardComponents
{
    public class _AdminDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IApiService<ResultStatisticDto> _statisticApiService;

        public _AdminDashboardStatisticsComponentPartial(IApiService<ResultStatisticDto> statisticApiService)
        {
            _statisticApiService = statisticApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Random random = new Random();

            var carCountTask = _statisticApiService.GetItemAsync("Statistics/GetCarCount");
            var brandCountTask = _statisticApiService.GetItemAsync("Statistics/GetBrandCount");
            var locationCountTask = _statisticApiService.GetItemAsync("Statistics/GetLocationCount");
            var avgCarRentPriceTask = _statisticApiService.GetItemAsync("Statistics/GetDailyAverageCarRentingPrice");

            await Task.WhenAll(carCountTask, brandCountTask, locationCountTask, avgCarRentPriceTask);

            #region statistic_1 - Car Count
            var carCountResult = carCountTask.Result;
            if (carCountResult != null)
            {
                int carCountRandom = random.Next(0, 101);
                ViewBag.carCount = carCountResult.CarCount.ToString();
                ViewBag.carCountRandom = carCountRandom;
            }
            #endregion

            #region statistic_2 - Brand Count
            var brandCountResult = brandCountTask.Result;
            if (brandCountResult != null)
            {
                int brandCountRandom = random.Next(0, 101);
                ViewBag.brandCount = brandCountResult.BrandCount.ToString();
                ViewBag.brandCountRandom = brandCountRandom;
            }
            #endregion

            #region statistic_3 - Location Count
            var locationCountResult = locationCountTask.Result;
            if (locationCountResult != null)
            {
                int locationCountRandom = random.Next(0, 101);
                ViewBag.locationCount = locationCountResult.LocationCount.ToString();
                ViewBag.locationCountRandom = locationCountRandom;
            }
            #endregion

            #region statistic_4 - Daily Average Car Renting Price
            var avgCarRentPriceResult = avgCarRentPriceTask.Result;
            if (avgCarRentPriceResult != null)
            {
                int d_AvgCarR_Price_Random = random.Next(0, 101);
                ViewBag.d_AvgCarR_Price = avgCarRentPriceResult.D_AvgCarR_Price.ToString("0.00");
                ViewBag.d_AvgCarR_Price_Random = d_AvgCarR_Price_Random;
            }
            #endregion

            return View();
        }
    }
}
