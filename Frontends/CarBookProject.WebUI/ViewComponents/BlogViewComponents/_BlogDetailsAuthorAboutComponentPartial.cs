using CarBook.Dto.AuthorgDtos;
 using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.FooterAddressComponents
{
    public class _BlogDetailsAuthorAboutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsAuthorAboutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7013/api/Blogs/GetBlogByAuthorId/"+ id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultGetAuthorByBlogAuthorIdDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
