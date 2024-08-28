using CarBook.Dto.ServiceDtos;
using CarBook.WebUI.Areas.CarBook.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace CarBook.WebUI.Areas.Site.ViewComponents.DefaultViewComponents
{
    public class _DefaultRandom4ServicesComponentPartial : ViewComponent
    {
        private readonly IApiCarBookService<ResultServiceDto> _apiService;

        public _DefaultRandom4ServicesComponentPartial(IApiCarBookService<ResultServiceDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/Services");
            var random = new Random();
            var randomValues = values.OrderBy(x => random.Next()).Take(4).ToList();

            return View(randomValues);
        }
    }
}
