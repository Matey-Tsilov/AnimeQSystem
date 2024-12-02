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
        IRepository<User, Guid> _userRepo
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
                quiz.CreatedAt = DateTime.Now;

                // TODO: Really inefficient
                // Get the creator's Id
                User? loggedInUser = _userRepo.GetAll().FirstOrDefault(u => u.IdentityUser.UserName == user.Identity?.Name);
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

            return AutoMapperConfig.MapperInstance.Map<BeginQuizViewModel>(quiz);
        }

    }
}
