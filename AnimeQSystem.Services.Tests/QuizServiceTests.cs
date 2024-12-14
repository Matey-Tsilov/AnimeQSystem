using AnimeQSystem.Data.Models;
using AnimeQSystem.Data.Models.Enums;
using AnimeQSystem.Data.Models.QuizSystem;
using AnimeQSystem.Data.Repositories.Interfaces;
using AnimeQSystem.Services.Interfaces;
using AnimeQSystem.Services.Mapping;
using AnimeQSystem.Web.Models.FormModels.AnimeQuiz;
using AnimeQSystem.Web.Models.ViewModels.AnimeQuiz;
using MockQueryable;
using Moq;
using System.Security.Claims;

namespace AnimeQSystem.Services.Tests
{
    public class QuizServiceTests
    {
        private static string imagesFolder = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\AnimeQSystem.Web\wwwroot\images"));

        static Guid fantasyGenreId = Guid.NewGuid();
        static Guid dramaGenreId = Guid.NewGuid();
        static Guid romanceGenreId = Guid.NewGuid();
        static Guid adventureGenreId = Guid.NewGuid();
        static Guid sliceOfLifeGenreId = Guid.NewGuid();

        // Hardcoded GUIDs for studios
        static Guid studioGhibliId = Guid.NewGuid();
        static Guid kyotoAnimationId = Guid.NewGuid();
        static Guid coMixWaveFilmsId = Guid.NewGuid();
        static Guid tohoAnimationId = Guid.NewGuid();
        static Guid madhouseId = Guid.NewGuid();

        // Hardcoded GUIDs for writers
        static Guid hayaoMiyazakiId = Guid.NewGuid();
        static Guid naokoYamadaId = Guid.NewGuid();
        static Guid makotoShinkaiId = Guid.NewGuid();

        // Hardcoded GUIDs for animes
        static Guid spiritedAwayId = Guid.NewGuid();
        static Guid silentVoiceId = Guid.NewGuid();
        static Guid yourNameId = Guid.NewGuid();

        // Hardcoded GUIDs for quizzes
        static Guid spiritedAwayQuizId = Guid.NewGuid();
        static Guid silentVoiceQuizId = Guid.NewGuid();
        static Guid yourNameQuizId = Guid.NewGuid();

        // Hardcoded GUIDs for characters
        static Guid chihiroOginoId = Guid.NewGuid();
        static Guid shouyaIshidaId = Guid.NewGuid();
        static Guid mitsuhaMiyamizuId = Guid.NewGuid();
        static Guid hakuId = Guid.NewGuid();
        static Guid noFaceId = Guid.NewGuid();
        static Guid shokoNishimiyaId = Guid.NewGuid();
        static Guid takiId = Guid.NewGuid();

        static Guid spiritedAwayQuestion1 = Guid.NewGuid();
        static Guid spiritedAwayQuestion2 = Guid.NewGuid();
        static Guid spiritedAwayQuestion3 = Guid.NewGuid();
        static Guid spiritedAwayQuestion4 = Guid.NewGuid();
        static Guid silentVoiceQuestion1 = Guid.NewGuid();
        static Guid silentVoiceQuestion2 = Guid.NewGuid();
        static Guid silentVoiceQuestion3 = Guid.NewGuid();
        static Guid yourNameQuestion1 = Guid.NewGuid();
        static Guid yourNameQuestion2 = Guid.NewGuid();

        private List<Quiz> quizData = new List<Quiz>()
        {
            new Quiz
            {
                Id = spiritedAwayQuizId,
                Title = "Spirited Away Quiz",
                Description = "Test your knowledge about Spirited Away.",
                CreatedAt = DateTime.UtcNow,
                CreatorId = Guid.NewGuid(),
                RewardPoints = 100,
                Image = File.ReadAllBytes(Path.Combine(imagesFolder, "quizzes", "spiritedaway.jpg"))
            },
            new Quiz
            {
                Id = silentVoiceQuizId,
                Title = "A Silent Voice Quiz",
                Description = "Test your knowledge about A Silent Voice.",
                CreatedAt = DateTime.UtcNow,
                CreatorId = Guid.NewGuid(),
                RewardPoints = 100,
                Image = File.ReadAllBytes(Path.Combine(imagesFolder, "quizzes", "silentvoice.jpg"))
            },
            new Quiz
            {
                Id = yourNameQuizId,
                Title = "Your Name Quiz",
                Description = "Test your knowledge about Your Name.",
                CreatedAt = DateTime.UtcNow,
                CreatorId = Guid.NewGuid(),
                RewardPoints = 100,
                Image = File.ReadAllBytes(Path.Combine(imagesFolder, "quizzes", "yourname.jpg"))
            }
        };

        private List<QuizQuestion> quizQuestionData = new List<QuizQuestion>()
        {

            // Spirited Away Quiz Questions
            new QuizQuestion
            {
                Id = spiritedAwayQuestion1,
                Title = "What is the name of the main protagonist in Spirited Away?",
                Answer = "Chihiro Ogino",
                QuizType = QuizType.MultipleChoice,
                QuizId = spiritedAwayQuizId
            },
            new QuizQuestion
            {
                Id = spiritedAwayQuestion2,
                Title = "Who runs the bathhouse in Spirited Away?",
                Answer = "Yubaba",
                QuizType = QuizType.MultipleChoice,
                QuizId = spiritedAwayQuizId
            },
            new QuizQuestion
            {
                Id = spiritedAwayQuestion3,
                Title = "What does Chihiro need to remember to return home?",
                QuizType = QuizType.WriteAnswer,
                Answer = "Her real name",
                QuizId = spiritedAwayQuizId
            },
            new QuizQuestion
            {
                Id = spiritedAwayQuestion4,
                Title = "True or False: No-Face is a spirit who tries to eat Chihiro.",
                QuizType = QuizType.TrueFalse,
                Answer = "False",
                QuizId = spiritedAwayQuizId
            },

            // A Silent Voice Quiz Questions
            new QuizQuestion
            {
                Id = silentVoiceQuestion1,
                Title = "What is the name of the main protagonist in A Silent Voice?",
                Answer = "Shoya Ishida",
                QuizType = QuizType.MultipleChoice,
                QuizId = silentVoiceQuizId
            },
            new QuizQuestion
            {
                Id = silentVoiceQuestion2,
                Title = "True or False: Shoya Ishida is a former bully in A Silent Voice.",
                QuizType = QuizType.TrueFalse,
                Answer = "True",
                QuizId = silentVoiceQuizId
            },
            new QuizQuestion
            {
                Id = silentVoiceQuestion3,
                Title = "Who does Shoya Ishida try to make amends with?",
                QuizType = QuizType.WriteAnswer,
                Answer = "Shoko Nishimiya",
                QuizId = silentVoiceQuizId
            },

            // Your Name Quiz Questions
            new QuizQuestion
            {
                Id = yourNameQuestion1,
                Title = "What is the name of the main character in Your Name?",
                QuizType = QuizType.MultipleChoice,
                Answer = "Mitsuha Miyamizu",
                QuizId = yourNameQuizId
            },
            new QuizQuestion
            {
                Id = yourNameQuestion2,
                Title = "True or False: Taki and Mitsuha swap bodies in Your Name.",
                QuizType = QuizType.TrueFalse,
                Answer = "True",
                QuizId = yourNameQuizId
            }
        };

        private List<QuizOption> quizOptionData = new List<QuizOption>()
        {
            new QuizOption
        {
            Id = Guid.NewGuid(),
            OptionText = "Chihiro Ogino",
            IsCorrect = true,
            QuizQuestionId = spiritedAwayQuestion1
        },
        new QuizOption
        {
            Id = Guid.NewGuid(),
            OptionText = "Satsuki Kusakabe",
            IsCorrect = false,
            QuizQuestionId = spiritedAwayQuestion1
        },
        new QuizOption
        {
            Id = Guid.NewGuid(),
            OptionText = "Nausicaä",
            IsCorrect = false,
            QuizQuestionId = spiritedAwayQuestion1
        },
        new QuizOption
        {
            Id = Guid.NewGuid(),
            OptionText = "Sophie Hatter",
            IsCorrect = false,
            QuizQuestionId = spiritedAwayQuestion1
        },
        new QuizOption
        {
            Id = Guid.NewGuid(),
            OptionText = "Yubaba",
            IsCorrect = true,
            QuizQuestionId = spiritedAwayQuestion2
        },
        new QuizOption
        {
            Id = Guid.NewGuid(),
            OptionText = "Zeniba",
            IsCorrect = false,
            QuizQuestionId = spiritedAwayQuestion2
        },
        new QuizOption
        {
            Id = Guid.NewGuid(),
            OptionText = "Kamaji",
            IsCorrect = false,
            QuizQuestionId = spiritedAwayQuestion2
        },
        new QuizOption
        {
            Id = Guid.NewGuid(),
            OptionText = "Haku",
            IsCorrect = false,
            QuizQuestionId = spiritedAwayQuestion2
        },

        // Options for A Silent Voice Quiz
        new QuizOption
        {
            Id = Guid.NewGuid(),
            OptionText = "Shoya Ishida",
            IsCorrect = true,
            QuizQuestionId = silentVoiceQuestion1
        },
        new QuizOption
        {
            Id = Guid.NewGuid(),
            OptionText = "Shoko Nishimiya",
            IsCorrect = false,
            QuizQuestionId = silentVoiceQuestion1
        },
        new QuizOption
        {
            Id = Guid.NewGuid(),
            OptionText = "Mitsuha Miyamizu",
            IsCorrect = false,
            QuizQuestionId = silentVoiceQuestion1
        },
        new QuizOption
        {
            Id = Guid.NewGuid(),
            OptionText = "Taki Tachibana",
            IsCorrect = false,
            QuizQuestionId = silentVoiceQuestion1
        },

        // Options for Your Name Quiz
        new QuizOption
        {
            Id = Guid.NewGuid(),
            OptionText = "Mitsuha Miyamizu",
            IsCorrect = true,
            QuizQuestionId = yourNameQuestion1
        },
        new QuizOption
        {
            Id = Guid.NewGuid(),
            OptionText = "Taki Tachibana",
            IsCorrect = true,
            QuizQuestionId = yourNameQuestion1
        },
        new QuizOption
        {
            Id = Guid.NewGuid(),
            OptionText = "Shoya Ishida",
            IsCorrect = false,
            QuizQuestionId = yourNameQuestion1
        },
        new QuizOption
        {
            Id = Guid.NewGuid(),
            OptionText = "Chihiro Ogino",
            IsCorrect = false,
            QuizQuestionId = yourNameQuestion1
        }
        };

        private Mock<IRepository<Quiz, Guid>> _quizRepoMock;
        private Mock<IUserService> _userServiceMock;
        private Mock<IQuizzesUsersService> _quizzesUsersServiceMock;

        private IQuizService _quizService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            AutoMapperConfig.RegisterMappings(typeof(QuizCardViewModel).Assembly);
        }

        [SetUp]
        public void Setup()
        {
            _quizRepoMock = new Mock<IRepository<Quiz, Guid>>();
            _userServiceMock = new Mock<IUserService>();
            _quizzesUsersServiceMock = new Mock<IQuizzesUsersService>();
            _quizService = new QuizService(_quizRepoMock.Object, _userServiceMock.Object, _quizzesUsersServiceMock.Object);
        }

        [Test]
        public async Task GetAllQuizzes_ReturnsMappedQuizCardViewModels()
        {
            _quizRepoMock.Setup(repo => repo.GetAllAttached()).Returns(quizData.BuildMock());

            var result = await _quizService.GetAllQuizzes();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("Spirited Away Quiz", result[0].Title);
            Assert.AreEqual("A Silent Voice Quiz", result[1].Title);
        }

        [Test]
        public async Task CreateQuiz_ValidUser_AddsQuizAndReturnsTrue()
        {
            var user = new User { Id = Guid.NewGuid(), FirstName = "George" };
            var formModel = new CreateQuizFormModel { Title = "New Quiz" };

            _userServiceMock.Setup(service => service.GetByEmail(It.IsAny<string>())).ReturnsAsync(user);

            var result = await _quizService.CreateQuiz(formModel, new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, "George") })));

            Assert.IsTrue(result);
            _quizRepoMock.Verify(repo => repo.AddAsync(It.Is<Quiz>(q => q.Title == "New Quiz" && q.CreatorId == user.Id)), Times.Once);
        }

        [Test]
        public async Task CreateQuiz_InvalidUser_ThrowsExceptionAndReturnsFalse()
        {
            var formModel = new CreateQuizFormModel { Title = "New Quiz" };

            _userServiceMock.Setup(service => service.GetByEmail(It.IsAny<string>())).ReturnsAsync((User)null);

            var result = await _quizService.CreateQuiz(formModel, new ClaimsPrincipal());

            Assert.IsFalse(result);
            _quizRepoMock.Verify(repo => repo.AddAsync(It.IsAny<Quiz>()), Times.Never);
        }

        [Test]
        public async Task CreateBeginQuizViewModel_ValidQuizId_ReturnsMappedViewModel()
        {
            var quiz = new Quiz { Id = Guid.NewGuid(), Title = "Sample Quiz" };

            _quizRepoMock.Setup(repo => repo.GetByIdAsync(quiz.Id)).ReturnsAsync(quiz);

            var result = await _quizService.CreateBeginQuizViewModel(quiz.Id);

            Assert.IsNotNull(result);
            Assert.AreEqual(quiz.QuizQuestions.Count(), result.QuizQuestions.Count());
            Assert.AreEqual("Sample Quiz", result.Title);
        }

        [Test]
        public void CreateBeginQuizViewModel_InvalidQuizId_ThrowsNullReferenceException()
        {
            // Arrange
            _quizRepoMock.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Quiz)null);

            // Act & Assert
            Assert.ThrowsAsync<NullReferenceException>(async () =>
                await _quizService.CreateBeginQuizViewModel(Guid.NewGuid())
            );
        }

        [Test]
        public async Task ValidateUserResult_ValidData_AddsPointsAndRecord()
        {
            var user = new User { Id = Guid.NewGuid(), FirstName = "user@test.com" };
            var quiz = new Quiz
            {
                Id = Guid.NewGuid(),
                RewardPoints = 100,
                QuizQuestions = new List<QuizQuestion>
                {
                    new QuizQuestion { Title = "Q1", Answer = "Answer1" },
                    new QuizQuestion { Title = "Q2", Answer = "Answer2" }
                }
            };

            var formModel = new EndQuizFormModel
            {
                QuizId = quiz.Id,
                UserAnswers = new List<EndQuizQuestionAnswerFormModel>
                {
                    new EndQuizQuestionAnswerFormModel { Title = "Q1", UserAnswer = "Answer1" },
                    new EndQuizQuestionAnswerFormModel { Title = "Q2", UserAnswer = "WrongAnswer" }
                }
            };

            _userServiceMock.Setup(service => service.GetByEmail(It.IsAny<string>())).ReturnsAsync(user);
            _quizRepoMock.Setup(repo => repo.GetByIdAsync(quiz.Id)).ReturnsAsync(quiz);

            await _quizService.ValidateUserResult(formModel, new ClaimsPrincipal());

            _quizzesUsersServiceMock.Verify(service => service.AddRecord(quiz.Id, user.Id, 50), Times.Once);
            _userServiceMock.Verify(service => service.AddRewardPoints(user, 50), Times.Once);
        }
    }
}
