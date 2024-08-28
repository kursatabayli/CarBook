using CarBook.Dto.BlogDtos;
using CarBook.Dto.CommentDtos;
using CarBook.WebUI.Areas.CarBook.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Site.ViewComponents.BlogViewComponents
{
    public class _BlogDetailMainComponentPartial : ViewComponent
    {
        private readonly IApiCarBookService<ResultGetBlogByIdDto> _blogApiService;
        private readonly IApiCarBookService<ResultCommentDto> _commentApiService;

        public _BlogDetailMainComponentPartial(IApiCarBookService<ResultGetBlogByIdDto> blogApiService, IApiCarBookService<ResultCommentDto> commentApiService)
        {
            _blogApiService = blogApiService;
            _commentApiService = commentApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var blogDetails = await _blogApiService.GetItemAsync($"https://localhost:7278/api/Blogs/{id}");

            var comments = await _commentApiService.GetListAsync($"https://localhost:7278/api/Comments/CommentByBlogId/{id}");
            ViewBag.commentCount = comments.Count;

            return View(blogDetails);
        }
    }
}
