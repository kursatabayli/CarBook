using CarBook.Dto.CarPricingWithCarsDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.ViewComponents.DashboardComponents
{
    public class _AdminDashboardCarPricingListComponentPartial : ViewComponent
    {
        private readonly IApiService<ResultCarPricingWithCarsDto> _apiService;

        public _AdminDashboardCarPricingListComponentPartial(IApiService<ResultCarPricingWithCarsDto> apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiService.GetListAsync("CarPricings/GetCarPricingWithDetails/");
            return View(values);

        }
    }
}
