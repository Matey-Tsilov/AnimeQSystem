using AnimeQSystem.Data.Models.Models;
using AnimeQSystem.Data.Models.QuizSystem;
using AnimeQSystem.Data.Repositories.Interfaces;
using AnimeQSystem.Services.Interfaces;
using AnimeQSystem.Web.Models.Enums;
using Moq;
using System.Linq.Expressions;

namespace AnimeQSystem.Services.Tests
{
    public class QuizzesUsersServiceTests
    {
        private readonly Mock<IRepository<QuizzesUsers, object>> _mockRepo;
        private readonly IQuizzesUsersService _quizzesUsersService;

        public QuizzesUsersServiceTests()
        {
            _mockRepo = new Mock<IRepository<QuizzesUsers, object>>();
            _quizzesUsersService = new QuizzesUsersService(_mockRepo.Object);
        }

        [Test]
        public async Task AddRecord_Should_Add_Record_When_Valid_Data_Is_Provided()
        {
            var quizId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            int points = 80;

            await _quizzesUsersService.AddRecord(quizId, userId, points);

            _mockRepo.Verify(repo => repo.AddAsync(It.Is<QuizzesUsers>(qus => qus.QuizId == quizId && qus.UserId == userId && qus.ResultPoints == points)), Times.Once);
        }

        [Test]
        public async Task GetUserResultForQuiz_Should_Throw_NullReferenceException_When_No_Record_Is_Found()
        {
            var quizId = Guid.NewGuid();
            var userId = Guid.NewGuid();

            _mockRepo.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<QuizzesUsers, bool>>>()))
                     .ReturnsAsync((QuizzesUsers?)null);

            var exception = Assert.ThrowsAsync<NullReferenceException>(() => _quizzesUsersService.GetUserResultForQuiz(quizId, userId));
            Assert.AreEqual("Such entry doesn't exist!", exception.Message);
        }

        [Test]
        public async Task GetUserResultForQuiz_Should_Return_Correct_UserResult_When_Record_Exists()
        {
            var quizId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var quiz = new Quiz
            {
                QuizQuestions = new List<QuizQuestion>
                {
                    new QuizQuestion(),
                    new QuizQuestion()
                },
                RewardPoints = 100
            };

            var quizzesUsers = new QuizzesUsers
            {
                QuizId = quizId,
                UserId = userId,
                ResultPoints = 80,
                Quiz = quiz
            };

            _mockRepo.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<QuizzesUsers, bool>>>()))
                     .ReturnsAsync(quizzesUsers);

            var result = await _quizzesUsersService.GetUserResultForQuiz(quizId, userId);

            Assert.AreEqual(2, result.AllQuestions);
            Assert.AreEqual(2, result.CorrectAnswers);
            Assert.AreEqual(80, result.Points);
            Assert.AreEqual(UserResult.Success, result.UserResult);
        }

        [Test]
        public async Task GetUserResultForQuiz_Should_Return_Perfect_UserResult_When_Full_Points_Are_Obtained()
        {
            var quizId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var quiz = new Quiz
            {
                QuizQuestions = new List<QuizQuestion>
                {
                    new QuizQuestion(),
                    new QuizQuestion()
                },
                RewardPoints = 100
            };

            var quizzesUsers = new QuizzesUsers
            {
                QuizId = quizId,
                UserId = userId,
                ResultPoints = 100,
                Quiz = quiz
            };

            _mockRepo.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<QuizzesUsers, bool>>>()))
                     .ReturnsAsync(quizzesUsers);

            var result = await _quizzesUsersService.GetUserResultForQuiz(quizId, userId);

            Assert.AreEqual(UserResult.Perfect, result.UserResult);
        }

        [Test]
        public async Task GetUserResultForQuiz_Should_Return_Fail_UserResult_When_Less_Than_Half_Points_Are_Obtained()
        {
            var quizId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var quiz = new Quiz
            {
                QuizQuestions = new List<QuizQuestion>
                {
                    new QuizQuestion(),
                    new QuizQuestion()
                },
                RewardPoints = 100
            };

            var quizzesUsers = new QuizzesUsers
            {
                QuizId = quizId,
                UserId = userId,
                ResultPoints = 40,
                Quiz = quiz
            };

            _mockRepo.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<QuizzesUsers, bool>>>()))
                     .ReturnsAsync(quizzesUsers);

            var result = await _quizzesUsersService.GetUserResultForQuiz(quizId, userId);

            Assert.AreEqual(UserResult.Fail, result.UserResult);
        }
    }
}