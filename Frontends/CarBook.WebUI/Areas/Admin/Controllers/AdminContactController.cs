using CarBook.Dto.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;


namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminContact")]
    
    public class AdminContactController : Controller
    {
        private readonly IApiAdminService<ResultContactDto> _apiService;

        public AdminContactController(IApiAdminService<ResultContactDto> apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _apiService.GetListAsync("https://localhost:7278/api/AdminContacts/");
            return View(values);
        }

    }
}
