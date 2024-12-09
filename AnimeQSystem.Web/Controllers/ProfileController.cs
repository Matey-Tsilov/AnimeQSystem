using AnimeQSystem.Common;
using AnimeQSystem.Services.Interfaces;
using AnimeQSystem.Web.Models.Mix;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeQSystem.Web.Controllers
{
    [Authorize]
    public class ProfileController(IUserService _userService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Details(string userId)
        {
            var user = await _userService.FindUserByIdentityUserId(userId);

            UserDetailsVFModel viewModel = _userService.CreateUserDetailsViewModel(user);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserProfile(UserDetailsVFModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Details), formModel);
            }

            // The email should remain unchanged
            var realUser = await _userService.GetById(formModel.Id);
            if (realUser!.IdentityUser.Email != formModel.Email)
            {
                throw new InvalidOperationException("Don't try to change user's email. It should remain the same");
            }

            // If the image has changed modify it in the DB as well
            if (formModel.ProfilePicForm is not null)
            {
                formModel.ProfilePicData = await MiscHelper.ConvertOrGetDefaultImage(formModel.ProfilePicForm, "user");
            }
            else
            {
                formModel.ProfilePicData = realUser.ProfilePic;
            }

            // Update the new details for the user
            await _userService.UpdateUserDetails(formModel);

            return RedirectToAction("All", "Quiz");
        }
    }
}
