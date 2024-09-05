using CarBook.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/BlogComment")]

    public class AdminBlogCommentController : Controller
    {
        private readonly IApiAdminService<ResultCommentDto> _apiService;

        public AdminBlogCommentController(IApiAdminService<ResultCommentDto> apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v = id;
            var values = await _apiService.GetListAsync($"https://localhost:7278/api/Comments/CommentByBlogId/{id}");
            return View(values);
        }

        [HttpDelete("RemoveComment/{id}")]
        public async Task<IActionResult> RemoveComment(int id)
        {
            await _apiService.RemoveItemAsync($"https://localhost:7278/api/AdminComments/{id}");
            return Ok();
        }


    }
}
