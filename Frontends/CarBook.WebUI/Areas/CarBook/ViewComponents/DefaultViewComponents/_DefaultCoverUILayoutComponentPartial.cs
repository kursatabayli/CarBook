using CarBook.Dto.BannerDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Site.ViewComponents.DefaultViewComponents
{
    public class _DefaultCoverUILayoutComponentPartial : ViewComponent
    {
        private readonly IApiService<ResultBannerDto> _apiService;

        public _DefaultCoverUILayoutComponentPartial(IApiService<ResultBannerDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiService.GetListAsync("Banners");
            return View(values);
        }
    }
}
