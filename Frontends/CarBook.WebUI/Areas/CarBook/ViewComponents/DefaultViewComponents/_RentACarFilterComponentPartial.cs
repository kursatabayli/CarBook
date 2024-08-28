using CarBook.Dto.LocationDtos;
using CarBook.WebUI.Areas.CarBook.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBook.WebUI.Areas.CarBook.ViewComponents.DefaultViewComponents
{
    public class _RentACarFilterComponentPartial:ViewComponent
    {
        private readonly IApiCarBookService<ResultLocationDto> _apiService;

        public _RentACarFilterComponentPartial(IApiCarBookService<ResultLocationDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var locationValues = await _apiService.GetListAsync("https://localhost:7278/api/Locations");

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
