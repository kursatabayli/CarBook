using CarBook.Dto.TagCloudDtos;
using CarBook.WebUI.Areas.CarBook.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Site.ViewComponents.BlogViewComponents
{
    public class _BlogDetailTagCloudComponentPartial : ViewComponent
    {
        private readonly IApiCarBookService<ResultGetTagCloudByIdDto> _apiService;

        public _BlogDetailTagCloudComponentPartial(IApiCarBookService<ResultGetTagCloudByIdDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.BlogID = id;
            var values = await _apiService.GetListAsync($"https://localhost:7278/api/TagClouds/GetTagCloudByBlogId/{id}");
            return View(values);
        }
    }
}
