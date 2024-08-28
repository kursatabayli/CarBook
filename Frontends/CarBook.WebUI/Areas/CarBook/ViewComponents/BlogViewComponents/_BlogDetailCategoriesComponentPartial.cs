using CarBook.Dto.CategoryDtos;
using CarBook.WebUI.Areas.CarBook.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Site.ViewComponents.BlogViewComponents
{
    public class _BlogDetailCategoriesComponentPartial : ViewComponent
    {
        private readonly IApiCarBookService<ResultCategoryDto> _apiService;

        public _BlogDetailCategoriesComponentPartial(IApiCarBookService<ResultCategoryDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/Categories");
            return View(values);
        }
    }
}
