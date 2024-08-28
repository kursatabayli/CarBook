using CarBook.Dto.BlogDtos;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.ViewComponents.DashboardComponents
{
    public class _AdminDashboardBlogListComponentPartial : ViewComponent
    {
        private readonly IApiAdminService<ResultGetAllBlogsWithAuthorsDto> _apiService;

        public _AdminDashboardBlogListComponentPartial(IApiAdminService<ResultGetAllBlogsWithAuthorsDto> apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/Blogs/GetAllBlogsWithAuthorsList/");
            return View(values);
        }
    }
}
