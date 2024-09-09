using CarBook.Dto.BlogDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Site.ViewComponents.BlogViewComponents
{
    public class _GetAuthorByBlogIdComponentPartial : ViewComponent
    {
        private readonly IApiService<ResultGetAuthorByBlogIdDto> _apiService;

        public _GetAuthorByBlogIdComponentPartial(IApiService<ResultGetAuthorByBlogIdDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.BlogID = id;
            var values = await _apiService.GetListAsync($"Blogs/GetAuthorByBlogIdList/{id}");
            return View(values);
        }
    }
}
