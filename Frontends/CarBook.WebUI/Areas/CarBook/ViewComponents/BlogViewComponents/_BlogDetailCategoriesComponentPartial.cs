using CarBook.Dto.CategoryDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Site.ViewComponents.BlogViewComponents
{
    public class _BlogDetailCategoriesComponentPartial : ViewComponent
    {
        private readonly IApiService<ResultCategoryDto> _apiService;

        public _BlogDetailCategoriesComponentPartial(IApiService<ResultCategoryDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiService.GetListAsync("Categories");
            return View(values);
        }
    }
}
