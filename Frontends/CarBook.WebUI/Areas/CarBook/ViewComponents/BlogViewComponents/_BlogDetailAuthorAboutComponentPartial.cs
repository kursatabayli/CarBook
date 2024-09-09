using CarBook.Dto.BlogDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Site.ViewComponents.BlogViewComponents
{
    public class _BlogDetailAuthorAboutComponentPartial : ViewComponent
    {
        private readonly IApiService<ResultGetAllBlogsWithAuthorsDto> _apiService;

        public _BlogDetailAuthorAboutComponentPartial(IApiService<ResultGetAllBlogsWithAuthorsDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiService.GetListAsync("Blogs/GetAllBlogsWithAuthorsList/");
            return View(values);
        }
    }
}
