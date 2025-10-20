using CarBook.Dto.BlogDtos;
using CarBook.Dto.FooterAdressDtos;
 using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.FooterAddressComponents
{
    public class _BlogDetailsMainComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsMainComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7013/api/Blogs/"+id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = Newtonsoft.Json.JsonConvert.DeserializeObject<ResultGetBlogById>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
