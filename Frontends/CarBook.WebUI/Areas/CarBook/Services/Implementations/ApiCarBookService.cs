using CarBook.WebUI.Areas.CarBook.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.CarBook.Services.Implementations
{
    public class ApiCarBookService<T> : IApiCarBookService<T>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiCarBookService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<T>> GetListAsync(string url)
        {
            var client = _httpClientFactory.CreateClient();

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
            var client = _httpClientFactory.CreateClient();

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
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(item);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(url, stringContent);

            return responseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> GetSingleAsync(string url)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync(url);
            return responseMessage.IsSuccessStatusCode;
        }
    }
}
