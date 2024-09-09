using CarBook.Dto.TestimonialDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CarBook.WebUI.Areas.Site.ViewComponents.TestimonialViewComponents
{
    public class _TestimonialComponentPartial : ViewComponent
    {
        private readonly IApiService<ResultTestimonialDto> _apiService;

        public _TestimonialComponentPartial(IApiService<ResultTestimonialDto> apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _apiService.GetListAsync("Testimonials");
            var random = new Random();
            var randomValues = values.OrderBy(x => random.Next()).Take(10).ToList();

            return View(randomValues);
        }
    }
}
