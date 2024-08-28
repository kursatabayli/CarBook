using CarBook.Dto.FooterAddressDtos;
using CarBook.WebUI.Areas.CarBook.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Site.ViewComponents.FooterAddressComponents
{
    public class _FooterAddressComponentPartial : ViewComponent
    {
        private readonly IApiCarBookService<ResultFooterAddressDto> _apiService;

        public _FooterAddressComponentPartial(IApiCarBookService<ResultFooterAddressDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/FooterAddresses");
            return View(values);

        }

    }
}
