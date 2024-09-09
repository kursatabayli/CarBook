using CarBook.Dto.BlogDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.ViewComponents.DashboardComponents
{
    public class _AdminDashboardBlogListComponentPartial : ViewComponent
    {
        private readonly IApiService<ResultGetAllBlogsWithAuthorsDto> _apiService;

        public _AdminDashboardBlogListComponentPartial(IApiService<ResultGetAllBlogsWithAuthorsDto> apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiService.GetListAsync("Blogs/GetAllBlogsWithAuthorsList/");
            return View(values);
        }
    }
}
