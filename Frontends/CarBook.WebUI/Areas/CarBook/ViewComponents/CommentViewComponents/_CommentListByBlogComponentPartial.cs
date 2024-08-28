using CarBook.Dto.CommentDtos;
using CarBook.Dto.TagCloudDtos;
using CarBook.WebUI.Areas.CarBook.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Site.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponentPartial : ViewComponent
    {
        private readonly IApiCarBookService<ResultCommentDto> _apiService;

        public _CommentListByBlogComponentPartial(IApiCarBookService<ResultCommentDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.BlogID = id;
            var values = await _apiService.GetListAsync($"https://localhost:7278/api/Comments/CommentByBlogId/{id}");
            return View(values);
        }
    }
}
