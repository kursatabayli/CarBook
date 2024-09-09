using CarBook.Dto.BrandDtos;
using CarBook.Dto.CarDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.ViewComponents.DashboardComponents
{
    public class _AdminDashboardChart2ComponentPartial : ViewComponent
    {
        private readonly IApiService<ResultCarWithBrandsDto> _carApiService;
        private readonly IApiService<ResultBrandDto> _brandApiService;

        public _AdminDashboardChart2ComponentPartial(IApiService<ResultCarWithBrandsDto> carApiService, IApiService<ResultBrandDto> brandApiService)
        {
            _carApiService = carApiService;
            _brandApiService = brandApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var carValue = await _carApiService.GetListAsync("Cars/");
            int carCount = carValue.Count;
            ViewBag.CarCount = carCount;

            var brandValue = await _brandApiService.GetListAsync("Brands/");
            int brandCount = brandValue.Count;
            ViewBag.BrandCount = brandCount;

            return View();
        }
    }
}
