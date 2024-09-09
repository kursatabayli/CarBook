using CarBook.Dto.BlogDtos;
using CarBook.Dto.CommentDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Site.ViewComponents.BlogViewComponents
{
    public class _BlogDetailMainComponentPartial : ViewComponent
    {
        private readonly IApiService<ResultGetBlogByIdDto> _blogApiService;
        private readonly IApiService<ResultCommentDto> _commentApiService;

        public _BlogDetailMainComponentPartial(IApiService<ResultGetBlogByIdDto> blogApiService, IApiService<ResultCommentDto> commentApiService)
        {
            _blogApiService = blogApiService;
            _commentApiService = commentApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var blogDetails = await _blogApiService.GetItemAsync($"Blogs/{id}");

            var comments = await _commentApiService.GetListAsync($"Comments/CommentByBlogId/{id}");
            ViewBag.commentCount = comments.Count;

            return View(blogDetails);
        }
    }
}
