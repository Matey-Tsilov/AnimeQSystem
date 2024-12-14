using AnimeQSystem.Common;
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
        IQuizzesUsersService _quizzesUsersService,
        ILogger<QuizController> _logger) : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(All));
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            try
            {
                var list = await _quizService.GetAllQuizzes();

                ViewBag.CurrentUser = await _userService.GetByEmail(User.Identity?.Name);

                AllQuizzesViewModel model = new AllQuizzesViewModel()
                {
                    AllQuizzes = list.OrderByDescending(i => i.CreatedAt).ToList()
                };

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("Can't see all quizzes dashboard: " + ex.Message);
                return View("~/Views/Errors/404.cshtml", ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuizFormModel formModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(formModel);
                }

                // Convert image to appropriate type
                formModel.Image = await MiscHelper.ConvertOrGetDefaultImage(formModel.ImageFile, "quiz");

                await _quizService.CreateQuiz(formModel, User);

                return RedirectToAction(nameof(All));
            }
            catch (Exception ex)
            {
                _logger.LogError("Can't create a quiz because: " + ex.Message);
                return View("~/Views/Errors/400.cshtml", ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Begin(Guid quizId)
        {
            try
            {
                bool userAlreadyDidQuiz = await _userService.UserDidQuiz(User.Identity?.Name, quizId);
                if (userAlreadyDidQuiz)
                {
                    return View("~/Views/Errors/400.cshtml", "User already did the quiz!");
                }

                BeginQuizViewModel viewModel = await _quizService.CreateBeginQuizViewModel(quizId);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Can't begin a quiz with id: {quizId}, because: " + ex.Message);
                return View("~/Views/Errors/400.cshtml", ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Finish(BeginQuizViewModel viewModel)
        {
            try
            {
                // TODO: Implement custom model binding
                EndQuizFormModel formModel = AutoMapperConfig.MapperInstance.Map<EndQuizFormModel>(viewModel);

                // TODO: Not the right place
                Guid? loggedInUserId = (await _userService.GetByEmail(User.Identity?.Name))?.Id;

                await _quizService.ValidateUserResult(formModel, User);

                return RedirectToAction(nameof(Feedback), new { userId = loggedInUserId, quizId = formModel.QuizId });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Can't finish a quiz with id: {viewModel.QuizId}, because: " + ex.Message);
                return View("~/Views/Errors/400.cshtml", ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Feedback(Guid userId, Guid quizId)
        {
            try
            {
                UserQuizResultViewModel viewModel = await _quizzesUsersService.GetUserResultForQuiz(quizId, userId);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Didn't recieve feedback for quiz with id: {quizId}, because: " + ex.Message);
                return View("~/Views/Errors/400.cshtml", ex.Message);
            }
        }

    }
}
