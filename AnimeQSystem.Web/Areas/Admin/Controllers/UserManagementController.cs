﻿using AnimeQSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeQSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserManagementController(IUserService _userService) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetUserManagementData()
        {
            var allUsersWithRanks = await _userService.GetAllRanked();

            return Json(allUsersWithRanks);
        }

        [HttpPost]
        public async Task<IActionResult> RecoverUser(Guid userId)
        {
            try
            {
                await _userService.GetByIdAndRecover(userId);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("~/Views/Errors/400.cshtml", ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SoftDeleteUser(Guid userId)
        {
            try
            {
                await _userService.GetByIdAndSoftDelete(userId);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("~/Views/Errors/400.cshtml", ex.Message);
            }
        }
    }
}