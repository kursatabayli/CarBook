using CarBook.Dto.BlogDtos;
using CarBook.WebUI.Areas.CarBook.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Site.ViewComponents.BlogViewComponents
{
    public class _BlogDetailRecentBlogsComponentPartial : ViewComponent
    {
        private readonly IApiCarBookService<ResultLast3BlogsWithAuthorsDto> _apiService;

        public _BlogDetailRecentBlogsComponentPartial(IApiCarBookService<ResultLast3BlogsWithAuthorsDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/Blogs/GetLast3BlogsWithAuthorsList");
            return View(values);
        }
    }
}
