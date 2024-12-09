using AnimeQSystem.Services.Interfaces;
using AnimeQSystem.Web.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeQSystem.Web.Controllers
{
    [Authorize]
    public class ProfileController(IUserService _userService) : Controller
    {
        public async Task<IActionResult> Details(string userId)
        {
            var user = await _userService.FindUserByIdentityUserId(userId);

            UserDetailsViewModel viewModel = _userService.CreateUserDetailsViewModel(user);

            return View(viewModel);
        }
    }
}
