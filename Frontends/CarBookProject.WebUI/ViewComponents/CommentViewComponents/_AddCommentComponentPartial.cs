using CarBook.Dto.BannerDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.CommentViewComponents
{
    public class _AddCommentComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AddCommentComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7013/api/Banners");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
