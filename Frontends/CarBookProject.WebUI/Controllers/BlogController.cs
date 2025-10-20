using CarBook.Dto.BlogDtos;
using CarBook.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.MainCoverText = "Blog Yazıları";
            ViewBag.MainCoverText2 = "Yazarlarımızın Blog Yazıları";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7013/api/Blogs/GetAllBlogsWithAuthorsList");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthors>>(jsonData);
                return View(values);
            }

            return View();
        }

        public async Task<IActionResult> BlogDetail(int Id)
        {
            ViewBag.MainCoverText = "Bloglar";
            ViewBag.MainCoverText2 = "Blog Detayı Ve Yorumlar";
            ViewBag.blogId = Id;
            return View();

        }
    }
}
