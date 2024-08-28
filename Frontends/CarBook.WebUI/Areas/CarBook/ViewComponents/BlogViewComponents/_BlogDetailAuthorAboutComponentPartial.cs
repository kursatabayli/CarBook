using CarBook.Dto.BlogDtos;
using CarBook.WebUI.Areas.CarBook.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Site.ViewComponents.BlogViewComponents
{
    public class _BlogDetailAuthorAboutComponentPartial : ViewComponent
    {
        private readonly IApiCarBookService<ResultGetAllBlogsWithAuthorsDto> _apiService;

        public _BlogDetailAuthorAboutComponentPartial(IApiCarBookService<ResultGetAllBlogsWithAuthorsDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/Blogs/GetAllBlogsWithAuthorsList/");
            return View(values);
        }
    }
}
