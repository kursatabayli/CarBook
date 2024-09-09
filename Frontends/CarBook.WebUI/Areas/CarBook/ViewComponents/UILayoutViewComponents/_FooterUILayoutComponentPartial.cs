using CarBook.Dto.FooterAddressDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Site.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentPartial : ViewComponent
    {
        private readonly IApiService<ResultFooterAddressDto> _apiService;

        public _FooterUILayoutComponentPartial(IApiService<ResultFooterAddressDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiService.GetListAsync("FooterAddresses");
            return View(values);

        }
    }
}
