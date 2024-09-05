using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminTestimonial")]
    
    public class AdminTestimonialController : Controller
    {
        private readonly IApiAdminService<ResultTestimonialDto> _apiService;

        public AdminTestimonialController(IApiAdminService<ResultTestimonialDto> apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/Testimonials/");
            return View(values);
        }

        [HttpDelete("RemoveTestimonial/{id}")]
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            await _apiService.RemoveItemAsync($"https://localhost:7278/api/AdminTestimonials/{id}");
            return Ok();
        }
    }
}
