using AnimeQSystem.Common;
using AnimeQSystem.Data.Models;
using AnimeQSystem.Data.Repositories.Interfaces;
using AnimeQSystem.Services.Interfaces;
using AnimeQSystem.Services.Mapping;
using AnimeQSystem.Web.Models.Mix;
using AnimeQSystem.Web.Models.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AnimeQSystem.Services
{
    public class UserService(IRepository<User, Guid> _userRepo, UserManager<IdentityUser> _userManager) : IUserService
    {
        public async Task<User?> GetByEmail(string? email)
        {
            return (await _userRepo.GetAllAsync()).FirstOrDefault(u => u.IdentityUser.Email?.ToUpper() == email?.ToUpper());
        }

        public async Task<User?> GetById(Guid id)
        {
            return await _userRepo.GetByIdAsync(id);
        }

        public async Task AddRewardPoints(User loggedInUser, int realResult)
        {
            loggedInUser.Points += realResult;
            await _userRepo.SaveChangesAsync();
        }

        public async Task<bool> UserDidQuiz(string? username, Guid quizId)
        {
            User? user = await GetByEmail(username);
            // TODO: Better error handling
            if (user is null) throw new NullReferenceException("There isn't a user with this username");

            return user.UserQuizzes.Any(q => q.QuizId == quizId);
        }

        public async Task CreateUserBasedOnIdentity(IdentityUser user, string fName, string lName, string country)
        {
            User appUser = new User()
            {
                FirstName = fName,
                LastName = lName,
                Country = country,
                IdentityUserId = user.Id,
                ProfilePic = await MiscHelper.ConvertOrGetDefaultImage(null, "user")
            };

            await _userRepo.AddAsync(appUser);
        }

        public async Task<User> FindUserByIdentityUserId(string identityUserId)
        {
            User? user = await _userRepo.FirstOrDefaultAsync(u => u.IdentityUserId == identityUserId);
            // TODO: Better error handling
            if (user is null) throw new NullReferenceException("There isn't a user with this identityUserId");

            return user;
        }

        public async Task<UserDetailsVFModel> CreateUserDetailsViewModel(User user)
        {
            var viewModel = AutoMapperConfig.MapperInstance.Map<UserDetailsVFModel>(user);

            var userRoles = await _userManager.GetRolesAsync(user.IdentityUser);

            // Get the role of the user
            viewModel.Role = userRoles.FirstOrDefault()!;

            return viewModel;
        }

        public async Task UpdateUserDetails(UserDetailsVFModel formModel)
        {
            User? user = await _userRepo.GetByIdAsync(formModel.Id);

            // TODO: Better error handling
            if (user is null) throw new NullReferenceException("There is no such user");

            User updatedUser = AutoMapperConfig.MapperInstance.Map(formModel, user);

            bool userIsUpdated = await _userRepo.UpdateAsync(updatedUser);

            // Update user role, if he is admin, editing his own profile, user can have only one role at a time
            if (formModel.Role is not null)
            {
                await _userManager.RemoveFromRoleAsync(user.IdentityUser, formModel.Role == "Admin" ? "User" : "Admin");
                await _userManager.AddToRoleAsync(user.IdentityUser, formModel.Role);
            }

            // TODO: Better error handling
            if (userIsUpdated is false) throw new InvalidOperationException("User couldn't be updated");
        }

        public async Task<List<LeaderboardUserViewModel>> GetAllRanked()
        {
            List<LeaderboardUserViewModel> allUsers = await Task.Run(() => _userRepo.GetAllAttached()
                .To<LeaderboardUserViewModel>()
                .OrderByDescending(x => x.Points)
                .ToList());

            return allUsers;
        }

        public async Task GetByIdAndSoftDelete(Guid userId)
        {
            await _userRepo.SoftDeleteAsync(userId);
        }

        public async Task GetByIdAndRecover(Guid userId)
        {
            var user = await _userRepo.GetByIdAsync(userId);
            if (user is null) throw new Exception("Such user doesn't exist!");

            user.IsDeleted = false;
            await _userRepo.SaveChangesAsync();
        }

        public async Task<byte[]?> CheckAndConvertImageFormData(IFormFile? profilePicForm, Guid userId)
        {
            var realUser = await _userRepo.GetByIdAsync(userId);

            if (profilePicForm is not null)
            {
                return await MiscHelper.ConvertOrGetDefaultImage(profilePicForm, "user");
            }
            else
            {
                return realUser!.ProfilePic;
            }
        }

        public async Task<bool> CheckIfUserChangedEmail(UserDetailsVFModel formModel)
        {
            var realUser = await _userRepo.GetByIdAsync(formModel.Id);
            if (realUser!.IdentityUser.Email != formModel.Email)
            {
                throw new InvalidOperationException("Don't try to change user's email. It should remain the same");
            }

            return true;
        }
    }
}
