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

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/Pricings");
            return View(values);

        }

        [HttpGet]
        [Route("CreatePricing")]
        public IActionResult CreatePricing()
        {
            return View();
        }

        [HttpPost]
        [Route("CreatePricing")]
        public async Task<IActionResult> CreatePricing(CreatePricingDto createPricingDto)
        {
            var success = await _createApiService.CreateItemAsync("https://localhost:7278/api/AdminPricings/", createPricingDto);
            if (success)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminPricing", new { area = "Admin" }) });

            }
            return View(createPricingDto);
        }

        [Route("RemovePricing/{id}")]
        public async Task<IActionResult> RemovePricing(int id)
        {
            var success = await _apiService.RemoveItemAsync($"https://localhost:7278/api/AdminPricings/{id}");
            if (success)
            {
                return RedirectToAction("Index");
            }
            return View();
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
            var success = await _updateApiService.UpdateItemAsync("https://localhost:7278/api/AdminPricings/", updatePricingDto);
            if (success)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminPricing", new { area = "Admin" }) });

            }
            return View(updatePricingDto);
        }
    }
}
