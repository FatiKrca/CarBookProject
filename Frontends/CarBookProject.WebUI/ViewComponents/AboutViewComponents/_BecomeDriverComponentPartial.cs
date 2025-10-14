using CarBook.Dto.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookProject.WebUI.ViewComponents.AboutViewComponents
{
    public class _BecomeDriverComponentPartial : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            return View();
        }
    }
}
