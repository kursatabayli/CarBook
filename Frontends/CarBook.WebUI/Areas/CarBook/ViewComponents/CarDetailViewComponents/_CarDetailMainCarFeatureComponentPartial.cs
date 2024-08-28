using CarBook.Dto.BannerDtos;
using CarBook.Dto.CarDtos;
using CarBook.WebUI.Areas.CarBook.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Site.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailMainCarFeatureComponentPartial : ViewComponent
    {
        private readonly IApiCarBookService<ResultCarDetailDto> _apiService;

        public _CarDetailMainCarFeatureComponentPartial(IApiCarBookService<ResultCarDetailDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.carid = id;
            var value = await _apiService.GetItemAsync($"https://localhost:7278/api/Cars/GetCarDetailsById/{id}");
            return View(value);
        }
    }
}
