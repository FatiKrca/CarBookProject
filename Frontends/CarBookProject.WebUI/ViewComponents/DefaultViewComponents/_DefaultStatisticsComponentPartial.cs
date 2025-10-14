using CarBook.Dto.BannerDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial : ViewComponent
    {
     
        public async Task<IViewComponentResult> InvokeAsync()
        {
           

            return View();
        }
    }
}
