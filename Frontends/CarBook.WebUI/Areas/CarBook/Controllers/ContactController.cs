using CarBook.Dto.ContactDtos;
using CarBook.WebUI.Areas.CarBook.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.CarBook.Controllers
{
    [Area("CarBook")]
    [Route("CarBook/[controller]")]
    public class ContactController : Controller
    {
        private readonly IApiCarBookService<CreateContactDto> _createApiService;

        public ContactController(IApiCarBookService<CreateContactDto> createApiService)
        {
            _createApiService = createApiService;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            ViewBag.v1 = "İletişim";
            ViewBag.v2 = "Bize Yazın";
            ViewBag.url = "/CarBook/Contact/Index/";
            return View();
        }

        [HttpPost("Index")]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            var value = await _createApiService.CreateItemAsync("https://localhost:7278/api/Contacts", createContactDto);
            if (value)
            {
                return RedirectToAction("Index", "Contact");
            }
            return View();
        }
    }
}
