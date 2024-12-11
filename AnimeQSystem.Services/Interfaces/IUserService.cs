using AnimeQSystem.Data.Models;
using AnimeQSystem.Web.Models.Mix;
using AnimeQSystem.Web.Models.ViewModels.User;
using Microsoft.AspNetCore.Identity;

namespace AnimeQSystem.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User?> GetByEmail(string? email);
        public Task<User?> GetById(Guid id);
        public Task AddRewardPoints(User loggedInUser, int realResult);
        public Task<bool> UserDidQuiz(string? username, Guid quizId);
        public Task CreateUserBasedOnIdentity(IdentityUser user, string fName, string lName, string country);
        public Task<User> FindUserByIdentityUserId(string identityUserId);
        public Task<UserDetailsVFModel> CreateUserDetailsViewModel(User user);
        public Task UpdateUserDetails(UserDetailsVFModel formModel);
        public Task<List<LeaderboardUserViewModel>> GetAllRanked();
        public Task GetByIdAndSoftDelete(Guid userId);
        public Task GetByIdAndRecover(Guid userId);
    }
}
