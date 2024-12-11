using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeQSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AnimeManagementController : Controller
    {
        // TODO: Make after the exam
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
