using CarBook.Dto.LoginDtos;
using CarBook.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminSettings")]
    public class AdminSettingsController : Controller
    {
        private readonly IApiService<UpdateUserDto> _apiService;

        public AdminSettingsController(IApiService<UpdateUserDto> apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            await _apiService.GetEmpty();
            return View();
        }

        [HttpPost("Index")]
        public async Task<IActionResult> Index(UpdateUserDto updateUserDto)
        {
            var user = await _apiService.GetItemAsync("AdminUser/");
            if (updateUserDto.OldPassword != user.OldPassword)
            {
                return Json(new { success = false, message = "Eski şifre yanlış." });
            }
            var value = await _apiService.UpdateItemAsync("AdminUser/", updateUserDto);
            return Json(new { success = true, redirectUrl = Url.Action("Index", "AdminSettings", new { area = "Admin" }) });
        }

    }
}
