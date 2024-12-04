using AnimeQSystem.Data.Models;

namespace AnimeQSystem.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User?> GetByEmail(string? email);
        public Task<User?> GetById(Guid id);
        public Task AddRewardPoints(User loggedInUser, int realResult);
        public Task<bool> UserDidQuiz(string? username, Guid quizId);
    }
}
