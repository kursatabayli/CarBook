using CarBook.Dto.CommentDtos;
using CarBook.Dto.TagCloudDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Site.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponentPartial : ViewComponent
    {
        private readonly IApiService<ResultCommentDto> _apiService;

        public _CommentListByBlogComponentPartial(IApiService<ResultCommentDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.BlogID = id;
            var values = await _apiService.GetListAsync($"Comments/CommentByBlogId/{id}");
            return View(values);
        }
    }
}
