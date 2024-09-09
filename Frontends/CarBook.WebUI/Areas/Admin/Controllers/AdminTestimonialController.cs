using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using CarBook.WebUI.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminTestimonial")]
    
    public class AdminTestimonialController : Controller
    {
        private readonly IApiService<ResultTestimonialDto> _apiService;

        public AdminTestimonialController(IApiService<ResultTestimonialDto> apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("Testimonials/");
            return View(values);
        }

        [HttpDelete("RemoveTestimonial/{id}")]
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            await _apiService.RemoveItemAsync($"AdminTestimonials/{id}");
            return Ok();
        }
    }
}
