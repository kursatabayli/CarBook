using CarBook.Dto.LocationDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBook.WebUI.Areas.CarBook.ViewComponents.DefaultViewComponents
{
    public class _RentACarFilterComponentPartial:ViewComponent
    {
        private readonly IApiService<ResultLocationDto> _apiService;

        public _RentACarFilterComponentPartial(IApiService<ResultLocationDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var locationValues = await _apiService.GetListAsync("Locations");

            var location = locationValues.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.LocationID.ToString()
            }).ToList();

            ViewBag.LocationValues = location;

            return View(ViewBag.LocationValues);
        }
    }
}
