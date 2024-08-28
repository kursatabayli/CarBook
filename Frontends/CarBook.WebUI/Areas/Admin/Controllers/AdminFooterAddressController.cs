using CarBook.Dto.FooterAddressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminFooterAddress")]
    
    public class AdminFooterAddressController : Controller
    {
        private readonly IApiAdminService<ResultFooterAddressDto> _apiService;
        private readonly IApiAdminService<CreateFooterAddressDto> _createApiService;
        private readonly IApiAdminService<UpdateFooterAddressDto> _updateApiService;

        public AdminFooterAddressController(IApiAdminService<ResultFooterAddressDto> apiService, IApiAdminService<CreateFooterAddressDto> createApiService, IApiAdminService<UpdateFooterAddressDto> updateApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/FooterAddresses/");
            return View(values);
        }

        [HttpGet]
        [Route("CreateFooterAddress")]
        public IActionResult CreateFooterAddress()
        {

            return View();
        }

        [HttpPost]
        [Route("CreateFooterAddress")]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressDto createFooterAddressDto)
        {
            var value = await _createApiService.CreateItemAsync("https://localhost:7278/api/AdminFooterAddresses/", createFooterAddressDto);
            if (value)
            {
                return RedirectToAction("Index");
            }
            return View(createFooterAddressDto);
        }

        [Route("RemoveFooterAddress/{id}")]
        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            await _apiService.RemoveItemAsync($"https://localhost:7278/api/AdminFooterAddresses/{id}");
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("UpdateFooterAddress/{id}")]
        public async Task<IActionResult> UpdateFooterAddress(int id)
        {
            var value = await _updateApiService.GetItemAsync($"https://localhost:7278/api/FooterAddresses/{id}");
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("UpdateFooterAddress/{id}")]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressDto updateFooterAddressDto)
        {
            var value = await _updateApiService.UpdateItemAsync("https://localhost:7278/api/AdminFooterAddresses/", updateFooterAddressDto);
            if (value)
            {
                return RedirectToAction("Index");
            }
            return View(updateFooterAddressDto);
        }
    }
}
