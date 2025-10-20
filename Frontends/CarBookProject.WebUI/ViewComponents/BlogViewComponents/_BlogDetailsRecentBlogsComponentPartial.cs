using CarBook.Dto.BlogDtos;
using CarBook.Dto.FooterAdressDtos;
 using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.FooterAddressComponents
{
    public class _BlogDetailsRecentBlogsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsRecentBlogsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7013/api/Blogs/Getlast3BlogsWithAuthorsList");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultLast3BlogsWithAuthors>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
