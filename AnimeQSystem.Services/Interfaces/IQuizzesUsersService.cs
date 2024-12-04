using AnimeQSystem.Web.Models.ViewModels.AnimeQuiz;

namespace AnimeQSystem.Services.Interfaces
{
    public interface IQuizzesUsersService
    {
        public Task AddRecord(Guid quizId, Guid userId, int points);
        public Task<UserQuizResultViewModel> GetUserResultForQuiz(Guid userId, Guid quizId);
    }
}
