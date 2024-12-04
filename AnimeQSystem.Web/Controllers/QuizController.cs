using AnimeQSystem.Services.Interfaces;
using AnimeQSystem.Services.Mapping;
using AnimeQSystem.Web.Models.FormModels.AnimeQuiz;
using AnimeQSystem.Web.Models.ViewModels.AnimeQuiz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeQSystem.Web.Controllers
{
    [Authorize]
    public class QuizController(
        IQuizService _quizService,
        IUserService _userService,
        IQuizzesUsersService _quizzesUsersService) : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(All));
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var list = await _quizService.GetAllQuizzes();

            ViewBag.CurrentUser = await _userService.GetByEmail(User.Identity?.Name);

            AllQuizzesViewModel model = new AllQuizzesViewModel()
            {
                AllQuizzes = list.OrderByDescending(i => i.CreatedAt).ToList()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuizFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return View(formModel);
            }

            await _quizService.CreateQuiz(formModel, User);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Begin(Guid quizId)
        {
            bool userAlreadyDidQuiz = await _userService.UserDidQuiz(User.Identity?.Name, quizId);
            if (userAlreadyDidQuiz)
            {
                return View("/Errors/404");
            }

            BeginQuizViewModel viewModel = await _quizService.CreateBeginQuizViewModel(quizId);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Finish(BeginQuizViewModel viewModel)
        {
            // TODO: Implement custom model binding
            EndQuizFormModel formModel = AutoMapperConfig.MapperInstance.Map<EndQuizFormModel>(viewModel);

            // TODO: Not the right place
            Guid? loggedInUserId = (await _userService.GetByEmail(User.Identity?.Name))?.Id;

            await _quizService.ValidateUserResult(formModel, User);

            return RedirectToAction(nameof(Feedback), new { userId = loggedInUserId, quizId = formModel.QuizId });
        }

        [HttpGet]
        public async Task<IActionResult> Feedback(Guid userId, Guid quizId)
        {
            UserQuizResultViewModel viewModel = await _quizzesUsersService.GetUserResultForQuiz(quizId, userId);

            return View(viewModel);
        }

    }
}
