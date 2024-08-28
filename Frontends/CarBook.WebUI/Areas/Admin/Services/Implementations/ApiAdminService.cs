using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;
using CarBook.WebUI.Areas.Admin.Services.Interfaces;

namespace CarBook.WebUI.Areas.Admin.Services.Implementations
{
    public class ApiAdminService<T> : IApiAdminService<T>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApiAdminService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        private HttpClient CreateClient()
        {
            var client = _httpClientFactory.CreateClient();

            var token = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == "carbooktoken")?.Value;

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            else
            {
                _httpContextAccessor.HttpContext?.Response.Redirect("/Admin/AdminLogin/Index");
                throw new UnauthorizedAccessException("Yetkilendirme hatası: Geçerli bir token bulunamadı.");
            }

            return client;
        }

        public async Task<List<T>> GetListAsync(string url)
        {
            var client = CreateClient();

            var responseMessage = await client.GetAsync(url);
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

            var responseMessage = await client.GetAsync(url);
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
            var responseMessage = await client.PostAsync(url, stringContent);

            return responseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(string url, T item)
        {
            var client = CreateClient();

            var jsonData = JsonConvert.SerializeObject(item);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(url, stringContent);

            return responseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveItemAsync(string url)
        {
            var client = CreateClient();

            var responseMessage = await client.DeleteAsync(url);
            return responseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> GetSingleAsync(string url)
        {
            var client = CreateClient();

            var responseMessage = await client.GetAsync(url);
            return responseMessage.IsSuccessStatusCode;
        }
    }
}
