using CarBook.Dto.StatisticDtos;
using CarBook.WebUI.Areas.CarBook.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CarBook.WebUI.Areas.Site.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial : ViewComponent
    {
        private readonly IApiCarBookService<ResultStatisticDto> _apiService;

        public _DefaultStatisticsComponentPartial(IApiCarBookService<ResultStatisticDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var carValues = await _apiService.GetItemAsync("https://localhost:7278/api/Statistics/GetCarCount");
            ViewBag.CarCount = carValues.CarCount;

            var locationValues = await _apiService.GetItemAsync("https://localhost:7278/api/Statistics/GetLocationCount");
            ViewBag.LocationCount = locationValues.LocationCount;

            var testimonialValues = await _apiService.GetItemAsync("https://localhost:7278/api/Statistics/GetTestimonialsCount");
            ViewBag.TestimonialsCount = testimonialValues.TestimonialsCount;

            return View();
        }
    }
}
