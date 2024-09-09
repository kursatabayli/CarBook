using CarBook.Dto.CarDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CarBook.WebUI.Areas.Site.ViewComponents.DefaultViewComponents
{
    public class _DefaultRandom5CarsComponentPartial : ViewComponent
    {
        private readonly IApiService<ResultRandom5CarsDto> _apiService;

        public _DefaultRandom5CarsComponentPartial(IApiService<ResultRandom5CarsDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiService.GetListAsync("CarPricings/GetCarPricingWithDetails");
            var random = new Random();
            var randomValues = values.OrderBy(x => random.Next()).Take(5).ToList();

            return View(randomValues);
        }
    }
}
