using CarBook.Dto.BlogDto;
using CarBook.Dto.TagCloudDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsMainComponentPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsMainComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.blogid = id;           
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7173/api/Blogs/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetBlogByIdDto>(jsonData);
                ViewBag.AuthorID = values.AuthorID;

                var responseMessage2 = await client.GetAsync($"https://localhost:7173/api/Comments/CommentCountByBlog?id=" + id);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.commentCount = jsonData2 != null ? jsonData2 : "0"; ;
                return View(values);
            }
            return View();
        }
    }
}
