using Microsoft.AspNetCore.Mvc;

namespace AnimeQSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Used to add the specific background image to the biggest container
            ViewData["BodyClass"] = "background-page";

            return View();
        }
    }
}
