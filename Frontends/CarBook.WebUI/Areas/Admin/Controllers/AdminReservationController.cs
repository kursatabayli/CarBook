using CarBook.Dto.ReservationDtos;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminReservation")]
    public class AdminReservationController : Controller
    {
        private readonly IApiAdminService<ResultReservationDto> _apiAdminService;

        public AdminReservationController(IApiAdminService<ResultReservationDto> apiAdminService)
        {
            _apiAdminService = apiAdminService;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiAdminService.GetListAsync("https://localhost:7278/api/AdminReservations/");
            return View(values);
        }
    }
}
