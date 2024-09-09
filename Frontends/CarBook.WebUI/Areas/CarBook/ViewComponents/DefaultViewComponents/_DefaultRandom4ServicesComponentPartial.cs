using CarBook.Dto.ServiceDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace CarBook.WebUI.Areas.Site.ViewComponents.DefaultViewComponents
{
    public class _DefaultRandom4ServicesComponentPartial : ViewComponent
    {
        private readonly IApiService<ResultServiceDto> _apiService;

        public _DefaultRandom4ServicesComponentPartial(IApiService<ResultServiceDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiService.GetListAsync("Services");
            var random = new Random();
            var randomValues = values.OrderBy(x => random.Next()).Take(4).ToList();

            return View(randomValues);
        }
    }
}
