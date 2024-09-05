using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminBlog")]
    
    public class AdminBlogController : Controller
    {
        private readonly IApiAdminService<ResultBlogDto> _apiService;

        public AdminBlogController(IApiAdminService<ResultBlogDto> apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/Blogs/GetAllBlogsWithAuthorsList");
            return View(values);
        }

        
        [HttpDelete("RemoveBlog/{id}")]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _apiService.RemoveItemAsync($"https://localhost:7278/api/AdminBlogs/{id}");
            return Ok();

        }
    }
}
