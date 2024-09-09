using CarBook.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using CarBook.WebUI.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/BlogComment")]

    public class AdminBlogCommentController : Controller
    {
        private readonly IApiService<ResultCommentDto> _apiService;

        public AdminBlogCommentController(IApiService<ResultCommentDto> apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v = id;
            var values = await _apiService.GetListAsync($"Comments/CommentByBlogId/{id}");
            return View(values);
        }

        [HttpDelete("RemoveComment/{id}")]
        public async Task<IActionResult> RemoveComment(int id)
        {
            await _apiService.RemoveItemAsync($"AdminComments/{id}");
            return Ok();
        }


    }
}
