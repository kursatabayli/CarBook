using CarBook.Dto.TestimonialDtos;
using CarBook.WebUI.Areas.CarBook.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CarBook.WebUI.Areas.Site.ViewComponents.TestimonialViewComponents
{
    public class _TestimonialComponentPartial : ViewComponent
    {
        private readonly IApiCarBookService<ResultTestimonialDto> _apiService;

        public _TestimonialComponentPartial(IApiCarBookService<ResultTestimonialDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/Testimonials");
            var random = new Random();
            var randomValues = values.OrderBy(x => random.Next()).Take(10).ToList();

            return View(randomValues);
        }
    }
}
