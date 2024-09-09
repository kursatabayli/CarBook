using CarBook.Dto.StatisticDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CarBook.WebUI.Areas.Site.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial : ViewComponent
    {
        private readonly IApiService<ResultStatisticDto> _apiService;

        public _DefaultStatisticsComponentPartial(IApiService<ResultStatisticDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var carValues = await _apiService.GetItemAsync("Statistics/GetCarCount");
            ViewBag.CarCount = carValues.CarCount;

            var locationValues = await _apiService.GetItemAsync("Statistics/GetLocationCount");
            ViewBag.LocationCount = locationValues.LocationCount;

            var testimonialValues = await _apiService.GetItemAsync("Statistics/GetTestimonialsCount");
            ViewBag.TestimonialsCount = testimonialValues.TestimonialsCount;

            return View();
        }
    }
}
