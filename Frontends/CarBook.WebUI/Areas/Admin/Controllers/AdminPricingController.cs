using CarBook.Dto.PricingDtos;
using Microsoft.AspNetCore.Mvc;
using CarBook.WebUI.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminPricing")]
    
    public class AdminPricingController : Controller
    {
        private readonly IApiService<ResultPricingDto> _apiService;
        private readonly IApiService<CreatePricingDto> _createApiService;
        private readonly IApiService<UpdatePricingDto> _updateApiService;

        public AdminPricingController(
            IApiService<ResultPricingDto> apiService,
            IApiService<CreatePricingDto> createApiService,
            IApiService<UpdatePricingDto> updateApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("Pricings");
            return View(values);

        }

        [HttpGet("CreatePricing")]
        public async Task<IActionResult> CreatePricing()
        {
            await _createApiService.GetEmpty();
            return View();
        }

        [HttpPost("CreatePricing")]
        public async Task<IActionResult> CreatePricing(CreatePricingDto createPricingDto)
        {
            var value = await _createApiService.CreateItemAsync("AdminPricings/", createPricingDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminPricing", new { area = "Admin" }) });

            }
            return View(createPricingDto);
        }

        [HttpDelete("RemovePricing/{id}")]
        public async Task<IActionResult> RemovePricing(int id)
        {
            await _apiService.RemoveItemAsync($"AdminPricings/{id}");
            return Ok();
        }

        [HttpGet]
        [Route("UpdatePricing/{id}")]
        public async Task<IActionResult> UpdatePricing(int id)
        {
            var value = await _updateApiService.GetItemAsync($"Pricings/{id}");
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("UpdatePricing/{id}")]
        public async Task<IActionResult> UpdatePricing(UpdatePricingDto updatePricingDto)
        {
            var value = await _updateApiService.UpdateItemAsync("AdminPricings/", updatePricingDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminPricing", new { area = "Admin" }) });

            }
            return View(updatePricingDto);
        }
    }
}
