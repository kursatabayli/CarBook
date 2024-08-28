using CarBook.Dto.CarPricingWithCarsDtos;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.ViewComponents.DashboardComponents
{
    public class _AdminDashboardCarPricingListComponentPartial : ViewComponent
    {
        private readonly IApiAdminService<ResultCarPricingWithCarsDto> _apiService;

        public _AdminDashboardCarPricingListComponentPartial(IApiAdminService<ResultCarPricingWithCarsDto> apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/CarPricings/GetCarPricingWithDetails/");
            return View(values);

        }
    }
}
