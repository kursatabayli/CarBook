using CarBook.Dto.BlogDtos;
using CarBook.WebUI.Areas.CarBook.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Site.ViewComponents.BlogViewComponents
{
    public class _GetAuthorByBlogIdComponentPartial : ViewComponent
    {
        private readonly IApiCarBookService<ResultGetAuthorByBlogIdDto> _apiService;

        public _GetAuthorByBlogIdComponentPartial(IApiCarBookService<ResultGetAuthorByBlogIdDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.BlogID = id;
            var values = await _apiService.GetListAsync($"https://localhost:7278/api/Blogs/GetAuthorByBlogIdList/{id}");
            return View(values);
        }
    }
}
