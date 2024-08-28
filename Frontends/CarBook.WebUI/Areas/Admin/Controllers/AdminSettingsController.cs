using CarBook.Dto.LoginDtos;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminSettings")]
    public class AdminSettingsController : Controller
    {
        private readonly IApiAdminService<UpdateUserDto> _apiService;

        public AdminSettingsController(IApiAdminService<UpdateUserDto> apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Index")]
        public async Task<IActionResult> Index(UpdateUserDto updateUserDto)
        {
            var user = await _apiService.GetItemAsync("https://localhost:7278/api/AdminUser/");
            if (updateUserDto.OldPassword != user.OldPassword)
            {
                return Json(new { success = false, message = "Eski şifre yanlış." });
            }
            var value = await _apiService.UpdateItemAsync($"https://localhost:7278/api/AdminUser/", updateUserDto);
            return RedirectToAction("Index");
        }

    }
}
