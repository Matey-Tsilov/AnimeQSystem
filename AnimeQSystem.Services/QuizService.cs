using AnimeQSystem.Data.Models;
using AnimeQSystem.Data.Models.QuizSystem;
using AnimeQSystem.Data.Repositories.Interfaces;
using AnimeQSystem.Services.Interfaces;
using AnimeQSystem.Services.Mapping;
using AnimeQSystem.Web.Models.FormModels.AnimeQuiz;
using AnimeQSystem.Web.Models.ViewModels.AnimeQuiz;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AnimeQSystem.Services
{
    public class QuizService(
        IRepository<Quiz, Guid> _quizRepo,
        IUserService _userService,
        IQuizzesUsersService _quizzesUsersService
        ) : IQuizService
    {
        public async Task<List<QuizCardViewModel>> GetAllQuizzes()
        {
            return await _quizRepo
                .GetAllAttached()
                .To<QuizCardViewModel>()
                .ToListAsync();
        }
        public async Task<bool> CreateQuiz(CreateQuizFormModel model, ClaimsPrincipal user)
        {
            try
            {
                // Map and set current time as creation
                Quiz quiz = AutoMapperConfig.MapperInstance.Map<Quiz>(model);
                quiz.CreatedAt = DateTime.UtcNow;

                // Get the creator's Id
                User? loggedInUser = await _userService.GetByEmail(user.Identity?.Name);
                if (loggedInUser is null) throw new NullReferenceException("Invalid logged-in user");
                quiz.CreatorId = loggedInUser.Id;

                await _quizRepo.AddAsync(quiz);
                return true;
            }
            catch (Exception ex)
            {
                // TODO: Logging and redirect to Error page
                return false;
            }
        }
        public async Task<BeginQuizViewModel> CreateBeginQuizViewModel(Guid quizId)
        {
            var quiz = await _quizRepo.GetByIdAsync(quizId);

            if (quiz is null)
            {
                throw new NullReferenceException("There is no such quiz, therefore you can't begin it");
            }

            BeginQuizViewModel vm = AutoMapperConfig.MapperInstance.Map<BeginQuizViewModel>(quiz);

            // Order the questions in the originaly created order
            vm.QuizQuestions.OrderByDescending(q => q.Index);

            return vm;
        }

        public async Task ValidateUserResult(EndQuizFormModel formModel, ClaimsPrincipal user)
        {
            User? loggedInUser = await _userService.GetByEmail(user.Identity?.Name);
            if (loggedInUser is null) throw new NullReferenceException("Invalid logged-in user");

            Quiz? currentQuiz = await _quizRepo.GetByIdAsync(formModel.QuizId);
            if (currentQuiz is null) throw new NullReferenceException("No such quiz existing");

            // Calculate user points for the quiz
            double allAnswers = currentQuiz.QuizQuestions.Count();
            int correctAnswers = GetUserCorrectAnswers(formModel, currentQuiz);
            int quizMaxPoints = currentQuiz.RewardPoints;
            int realResult = (int)Math.Truncate(correctAnswers / allAnswers * quizMaxPoints * 1d);

            // Add the new record to the mapping table
            await _quizzesUsersService.AddRecord(formModel.QuizId, loggedInUser.Id, realResult);

            // Add the corresponding reward points
            await _userService.AddRewardPoints(loggedInUser, realResult);
        }

        private int GetUserCorrectAnswers(EndQuizFormModel userQuiz, Quiz realQuiz)
        {
            int correct = 0;
            int questionsCount = realQuiz.QuizQuestions.Count();

            for (int i = 0; i < questionsCount; i++)
            {
                string searchedTitle = realQuiz.QuizQuestions[i].Title;
                string realAnswer = realQuiz.QuizQuestions[i].Answer;

                string? userAnswer = userQuiz.UserAnswers.FirstOrDefault(x => x.Title == searchedTitle)?.UserAnswer;

                // TODO: Ask AI to decipher answers and say if it is correct or no
                if (userAnswer?.ToLower() == realAnswer.ToLower())
                {
                    correct++;
                }
            }

            return correct;

        }
    }
}
