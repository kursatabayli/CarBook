using CarBook.Dto.BlogDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Site.ViewComponents.BlogViewComponents
{
    public class _BlogDetailRecentBlogsComponentPartial : ViewComponent
    {
        private readonly IApiService<ResultLast3BlogsWithAuthorsDto> _apiService;

        public _BlogDetailRecentBlogsComponentPartial(IApiService<ResultLast3BlogsWithAuthorsDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiService.GetListAsync("Blogs/GetLast3BlogsWithAuthorsList");
            return View(values);
        }
    }
}
