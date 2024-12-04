using Microsoft.AspNetCore.Mvc;

namespace AnimeQSystem.Web.Controllers
{
    public class LeaderboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
