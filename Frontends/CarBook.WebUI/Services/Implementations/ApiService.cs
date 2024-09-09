using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;
using CarBook.WebUI.Services.Interfaces;

namespace CarBook.WebUI.Services.Implementations
{
    public class ApiService<T> : IApiService<T>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;
        public ApiService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _baseUrl = _configuration["ApiUrls:BaseApiUrl"]!;
        }


        private HttpClient CreateClient()
        {
            var client = _httpClientFactory.CreateClient();
            var area = _httpContextAccessor.HttpContext?.Request.RouteValues["area"]?.ToString();

            if (area == "Admin")
            {
                var token = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == "carbooktoken")?.Value;

                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                else
                {
                    _httpContextAccessor.HttpContext?.Response.Redirect("/Admin/AdminLogin/Index");
                    _httpContextAccessor.HttpContext?.Response.CompleteAsync();
                    return null!;
                }
            }
            return client;
        }

        public async Task<List<T>> GetListAsync(string url)
        {
            var client = CreateClient();

            var responseMessage = await client.GetAsync(_baseUrl + url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<T>>(jsonData);
            }

            return new List<T>();
        }

        public async Task<T> GetItemAsync(string url)
        {
            var client = CreateClient();

            var responseMessage = await client.GetAsync(_baseUrl + url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonData);
            }

            return default;
        }

        public async Task<bool> CreateItemAsync(string url, T item)
        {
            var client = CreateClient();

            var jsonData = JsonConvert.SerializeObject(item);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(_baseUrl + url, stringContent);

            return responseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(string url, T item)
        {
            var client = CreateClient();

            var jsonData = JsonConvert.SerializeObject(item);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(_baseUrl + url, stringContent);

            return responseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveItemAsync(string url)
        {
            var client = CreateClient();

            var responseMessage = await client.DeleteAsync(_baseUrl + url);
            return responseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> GetSingleAsync(string url)
        {
            var client = CreateClient();

            var responseMessage = await client.GetAsync(_baseUrl + url);
            return responseMessage.IsSuccessStatusCode;
        }

        public async Task GetEmpty()
        {
            var client = CreateClient();
        }
    }
}
