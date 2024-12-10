using AnimeQSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnimeQSystem.Web.Controllers
{
    public class LeaderboardController(IUserService _userService) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetLeaderboardData()
        {
            var allUsersWithRanks = await _userService.GetAllRanked();

            return Json(allUsersWithRanks);
        }
    }
}
