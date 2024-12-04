using AnimeQSystem.Data.Models.Models;
using AnimeQSystem.Data.Repositories.Interfaces;
using AnimeQSystem.Services.Interfaces;
using AnimeQSystem.Web.Models.Enums;
using AnimeQSystem.Web.Models.ViewModels.AnimeQuiz;

namespace AnimeQSystem.Services
{
    public class QuizzesUsersService(IRepository<QuizzesUsers, object> _quizzesUsersRepo) : IQuizzesUsersService
    {
        public async Task AddRecord(Guid quizId, Guid userId, int points)
        {
            QuizzesUsers qu = new QuizzesUsers()
            {
                QuizId = quizId,
                UserId = userId,
                ResultPoints = points
            };

            await _quizzesUsersRepo.AddAsync(qu);

        }

        public async Task<UserQuizResultViewModel> GetUserResultForQuiz(Guid quizId, Guid userId)
        {
            QuizzesUsers? userResultForQuiz = await _quizzesUsersRepo.FirstOrDefaultAsync(qus => qus.QuizId == quizId && qus.UserId == userId);
            if (userResultForQuiz is null) throw new NullReferenceException("Such entry doesn't exist!");

            int allAnswers = userResultForQuiz.Quiz.QuizQuestions.Count();
            int quizMaxPoints = userResultForQuiz.Quiz.RewardPoints;
            int realUserResult = userResultForQuiz.ResultPoints;
            int correctAnswers = (int)Math.Round((double)realUserResult / quizMaxPoints * allAnswers); //TODO: Risk of loosing correct answers when rounding

            // Decide user result enum
            UserQuizResultViewModel userResult = new UserQuizResultViewModel();
            if (realUserResult == quizMaxPoints) userResult.UserResult = UserResult.Perfect;
            else if (realUserResult > (quizMaxPoints / 2)) userResult.UserResult = UserResult.Success;
            else userResult.UserResult = UserResult.Fail;

            // Add general values too
            userResult.AllQuestions = (int)allAnswers;
            userResult.CorrectAnswers = correctAnswers;
            userResult.Points = realUserResult;

            return userResult;
        }
    }
}
