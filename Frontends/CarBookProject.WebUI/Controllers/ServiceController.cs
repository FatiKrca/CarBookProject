using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.MainCoverText = "Hizmetler";
            ViewBag.MainCoverText2 = "Hizmetlerimiz";
            return View();
        }
    }
}
