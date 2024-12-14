using AnimeQSystem.Services.Interfaces;
using AnimeQSystem.Web.Models.Mix;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Security.Application;

namespace AnimeQSystem.Web.Controllers
{
    [Authorize]
    public class ProfileController(IUserService _userService, ILogger<ProfileController> _logger) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Details(string userId)
        {
            try
            {
                string userIdSafe = Sanitizer.GetSafeHtmlFragment(userId);
                var user = await _userService.FindUserByIdentityUserId(userIdSafe);

                UserDetailsVFModel viewModel = await _userService.CreateUserDetailsViewModel(user);

                // We have this property to change view look based on who is the currently logged in user
                var currentlyLoggedInUser = HttpContext.Items["CurrentUser"] as UserDetailsVFModel;
                if (user.Id == currentlyLoggedInUser!.Id)
                {
                    viewModel.IsSameUser = true;
                }

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Can't open the user details view: " + ex.Message);
                return View("~/Views/Errors/404.cshtml", ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserProfile(UserDetailsVFModel formModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(nameof(Details), formModel);
                }

                // The email should remain unchanged
                await _userService.CheckIfUserChangedEmail(formModel);

                // If the image has changed modify it in the DB as well
                formModel.ProfilePicData = await _userService.CheckAndConvertImageFormData(formModel.ProfilePicForm, formModel.Id);

                // Update the new details for the user
                await _userService.UpdateUserDetails(formModel);

                return RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {
                _logger.LogError("Can't save user made changes to profile: " + ex.Message);
                return View("~/Views/Errors/404.cshtml", ex.Message);
            }
        }
    }
}
