using CarBook.Dto.BlogDtos;
using CarBook.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailMainComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailMainComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7278/api/Blogs/{id}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                return View();
            }
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var blogDetails = JsonConvert.DeserializeObject<ResultGetBlogByIdDto>(jsonData);


            var commentResponse = await client.GetAsync($"https://localhost:7278/api/Comments/CommentByBlogId?id={id}");
            if (!commentResponse.IsSuccessStatusCode)
            {
                return View(blogDetails);
            }

            var commentJson = await commentResponse.Content.ReadAsStringAsync();
            var comments = JsonConvert.DeserializeObject<List<ResultCommentDto>>(commentJson);
            ViewBag.commentCount = comments.Count;


            return View(blogDetails);
        }
    }
}
