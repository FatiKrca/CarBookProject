using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.MainCoverText="Hakkımızda";
            ViewBag.MainCoverText2="Vizyonumuz % Misyonumuz";
            return View();
        }
    }
}
