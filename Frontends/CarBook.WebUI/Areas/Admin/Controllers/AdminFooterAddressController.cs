using CarBook.Dto.FooterAddressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using CarBook.WebUI.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminFooterAddress")]
    
    public class AdminFooterAddressController : Controller
    {
        private readonly IApiService<ResultFooterAddressDto> _apiService;
        private readonly IApiService<CreateFooterAddressDto> _createApiService;
        private readonly IApiService<UpdateFooterAddressDto> _updateApiService;

        public AdminFooterAddressController(IApiService<ResultFooterAddressDto> apiService, IApiService<CreateFooterAddressDto> createApiService, IApiService<UpdateFooterAddressDto> updateApiService)
        {
            _apiService = apiService;
            _createApiService = createApiService;
            _updateApiService = updateApiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("FooterAddresses/");
            return View(values);
        }

        [HttpGet("CreateFooterAddress")]
        public async Task<IActionResult> CreateFooterAddress()
        {

            await _createApiService.GetEmpty();
            return View();
        }

        [HttpPost("CreateFooterAddress")]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressDto createFooterAddressDto)
        {
            var value = await _createApiService.CreateItemAsync("AdminFooterAddresses/", createFooterAddressDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminFooterAddress", new { area = "Admin" }) });

            }
            return View(createFooterAddressDto);
        }

        [HttpDelete("RemoveFooterAddress/{id}")]
        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            await _apiService.RemoveItemAsync($"AdminFooterAddresses/{id}");
            return Ok();
        }

        [HttpGet("UpdateFooterAddress/{id}")]
        public async Task<IActionResult> UpdateFooterAddress(int id)
        {
            var value = await _updateApiService.GetItemAsync($"FooterAddresses/{id}");
            if (value != null)
            {
                return View(value);
            }
            return RedirectToAction("Index");
        }

        [HttpPost("UpdateFooterAddress/{id}")]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressDto updateFooterAddressDto)
        {
            var value = await _updateApiService.UpdateItemAsync("AdminFooterAddresses/", updateFooterAddressDto);
            if (value)
            {
                return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminFooterAddress", new { area = "Admin" }) });

            }
            return View(updateFooterAddressDto);
        }
    }
}
