using CarBook.Dto.BrandDtos;
using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.ViewComponents.DashboardComponents
{
    public class _AdminDashboardChart2ComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardChart2ComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();


            var carResponse = await client.GetAsync("https://localhost:7278/api/Cars");
            var carJson = await carResponse.Content.ReadAsStringAsync();
            var cars = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(carJson);
            int carCount = cars.Count;
            ViewBag.CarCount = carCount;

            var brandResponse = await client.GetAsync("https://localhost:7278/api/Brands");
            var brandJson = await brandResponse.Content.ReadAsStringAsync();
            var brands = JsonConvert.DeserializeObject<List<ResultBrandDto>>(brandJson);
            int brandCount = brands.Count;
            ViewBag.BrandCount = brandCount;

            return View();
        }
    }
}
