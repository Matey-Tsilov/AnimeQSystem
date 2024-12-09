using AnimeQSystem.Common;
using AnimeQSystem.Data.Models;
using AnimeQSystem.Data.Repositories.Interfaces;
using AnimeQSystem.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AnimeQSystem.Services
{
    public class UserService(IRepository<User, Guid> _userRepo) : IUserService
    {
        public async Task<User?> GetByEmail(string? email)
        {
            return (await _userRepo.GetAllAsync()).FirstOrDefault(u => u.IdentityUser.Email?.ToUpper() == email?.ToUpper());
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
    }
}
