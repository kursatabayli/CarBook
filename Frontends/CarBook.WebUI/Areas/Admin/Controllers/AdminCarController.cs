using CarBook.Dto.BrandDtos;
using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCar")]
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "carbooktoken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = await client.GetAsync("https://localhost:7278/api/Cars/CarsListWithBrandAndOtherFeatures");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(jsonData);
                    return View(values);
                }
            }
            return View();
        }

        [HttpGet]
        [Route("CreateCar")]
        public async Task<IActionResult> CreateCar()
        {
            var client = _httpClientFactory.CreateClient();

            var brandResponse = await client.GetAsync("https://localhost:7278/api/Brands");
            var brandJson = await brandResponse.Content.ReadAsStringAsync();
            var brands = JsonConvert.DeserializeObject<List<ResultGetBrandsDto>>(brandJson);
            List<SelectListItem> brandValues = (from x in brands
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.BrandID.ToString(),
                                                }).ToList();
            ViewBag.BrandValues = brandValues;

            var fuelResponse = await client.GetAsync("https://localhost:7278/api/Cars/FeulTypes");
            var fuelJson = await fuelResponse.Content.ReadAsStringAsync();
            var fuels = JsonConvert.DeserializeObject<List<FuelDto>>(fuelJson);
            List<SelectListItem> fuelValues = (from x in fuels
                                               select new SelectListItem
                                               {
                                                   Text = x.FuelType,
                                                   Value = x.CarFuelID.ToString(),
                                               }).ToList();
            ViewBag.FuelValues = fuelValues;

            var luggageResponse = await client.GetAsync("https://localhost:7278/api/Cars/LuggageTypes");
            var luggageJson = await luggageResponse.Content.ReadAsStringAsync();
            var luggages = JsonConvert.DeserializeObject<List<LuggageDto>>(luggageJson);
            List<SelectListItem> luggageValues = (from x in luggages
                                                  select new SelectListItem
                                                  {
                                                      Text = x.LuggageType,
                                                      Value = x.CarLuggageID.ToString(),
                                                  }).ToList();
            ViewBag.LuggageValues = luggageValues;

            var transmissionResponse = await client.GetAsync("https://localhost:7278/api/Cars/TransmissionTypes");
            var transmissionJson = await transmissionResponse.Content.ReadAsStringAsync();
            var transmissions = JsonConvert.DeserializeObject<List<TransmissionDto>>(transmissionJson);
            List<SelectListItem> transmissionValues = (from x in transmissions
                                                       select new SelectListItem
                                                       {
                                                           Text = x.TransmissionType,
                                                           Value = x.CarTransmissionID.ToString(),
                                                       }).ToList();
            ViewBag.TransmissionValues = transmissionValues;

            return View();
        }

        [HttpPost]
        [Route("CreateCar")]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7278/api/AdminCars/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminCar", new { area = "Admin" });
            }
            return View();
        }

        [Route("RemoveCar/{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7278/api/AdminCars/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminCar", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateCar/{id}")]

        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var brandResponse = await client.GetAsync("https://localhost:7278/api/Brands");
            var brandJson = await brandResponse.Content.ReadAsStringAsync();
            var brands = JsonConvert.DeserializeObject<List<ResultGetBrandsDto>>(brandJson);
            List<SelectListItem> brandValues = (from x in brands
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.BrandID.ToString(),
                                                }).ToList();
            ViewBag.BrandValues = brandValues;

            var fuelResponse = await client.GetAsync("https://localhost:7278/api/Cars/FeulTypes");
            var fuelJson = await fuelResponse.Content.ReadAsStringAsync();
            var fuels = JsonConvert.DeserializeObject<List<FuelDto>>(fuelJson);
            List<SelectListItem> fuelValues = (from x in fuels
                                               select new SelectListItem
                                               {
                                                   Text = x.FuelType,
                                                   Value = x.CarFuelID.ToString(),
                                               }).ToList();
            ViewBag.FuelValues = fuelValues;

            var luggageResponse = await client.GetAsync("https://localhost:7278/api/Cars/LuggageTypes");
            var luggageJson = await luggageResponse.Content.ReadAsStringAsync();
            var luggages = JsonConvert.DeserializeObject<List<LuggageDto>>(luggageJson);
            List<SelectListItem> luggageValues = (from x in luggages
                                                  select new SelectListItem
                                                  {
                                                      Text = x.LuggageType,
                                                      Value = x.CarLuggageID.ToString(),
                                                  }).ToList();
            ViewBag.LuggageValues = luggageValues;

            var transmissionResponse = await client.GetAsync("https://localhost:7278/api/Cars/TransmissionTypes");
            var transmissionJson = await transmissionResponse.Content.ReadAsStringAsync();
            var transmissions = JsonConvert.DeserializeObject<List<TransmissionDto>>(transmissionJson);
            List<SelectListItem> transmissionValues = (from x in transmissions
                                                       select new SelectListItem
                                                       {
                                                           Text = x.TransmissionType,
                                                           Value = x.CarTransmissionID.ToString(),
                                                       }).ToList();
            ViewBag.TransmissionValues = transmissionValues;

            var responseMessage = await client.GetAsync($"https://localhost:7278/api/AdminCars/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);
                return View(values);

            }
            return View();
        }

        [HttpPost]
        [Route("UpdateCar/{id}")]

        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCarDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7278/api/AdminCars/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminCar", new { area = "Admin" });
            }
            return View();
        }

    }
}
