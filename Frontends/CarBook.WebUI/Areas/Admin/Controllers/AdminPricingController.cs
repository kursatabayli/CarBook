using CarBook.Dto.PricingDtos;
using Microsoft.AspNetCore.Mvc;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminPricing")]
    
    public class AdminPricingController : Controller
    {
        private readonly IApiAdminService<ResultPricingDto> _apiService;
        private readonly IApiAdminService<CreatePricingDto> _createApiService;
        private readonly IApiAdminService<UpdatePricingDto> _updateApiService;

        public AdminPricingController(
            IApiAdminService<ResultPricingDto> apiService,
            IApiAdminService<CreatePricingDto> createApiService,
            IApiAdminService<UpdatePricingDto> updateApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/Pricings");
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
            var value = await _createApiService.CreateItemAsync("https://localhost:7278/api/AdminPricings/", createPricingDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminPricing", new { area = "Admin" }) });

            }
            return View(createPricingDto);
        }

        [HttpDelete("RemovePricing/{id}")]
        public async Task<IActionResult> RemovePricing(int id)
        {
            await _apiService.RemoveItemAsync($"https://localhost:7278/api/AdminPricings/{id}");
            return Ok();
        }

        [HttpGet]
        [Route("UpdatePricing/{id}")]
        public async Task<IActionResult> UpdatePricing(int id)
        {
            var value = await _updateApiService.GetItemAsync($"https://localhost:7278/api/Pricings/{id}");
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
            var value = await _updateApiService.UpdateItemAsync("https://localhost:7278/api/AdminPricings/", updatePricingDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminPricing", new { area = "Admin" }) });

            }
            return View(updatePricingDto);
        }
    }
}
