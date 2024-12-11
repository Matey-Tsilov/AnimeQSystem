using AnimeQSystem.Data.Models.AnimeSystem;
using AnimeQSystem.Data.Models.Enums;
using AnimeQSystem.Data.Repositories.Interfaces;
using AnimeQSystem.Services.Interfaces;
using AnimeQSystem.Services.Mapping;
using AnimeQSystem.Web.Models.ViewModels.Anime;
using AnimeQSystem.Web.Models.ViewModels.AnimeQuiz;
using MockQueryable;
using Moq;

namespace AnimeQSystem.Services.Tests
{
    public class AnimeServiceTests
    {
        private static string imagesFolder = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\AnimeQSystem.Web\wwwroot\images"));

        private List<Anime> animesData = new List<Anime>()
        {
            new Anime
            {
                Id = Guid.NewGuid(),
                Title = "Spirited Away",
                AnimePic = File.ReadAllBytes(Path.Combine(imagesFolder, "quizzes", "spiritedaway.jpg")),
                Description = "Chihiro, a young girl, finds herself trapped in a magical realm ruled by spirits and gods. As she fights to rescue her parents and return home, she discovers courage, compassion, and the value of identity.",
                Episodes = 1,
                Seasons = 1,
                ReleaseDate = new DateTime(2001, 7, 20),
                StillOngoing = false,
                Rating = Rating.Excellent,
                WriterId = Guid.NewGuid(),
                StudioId = Guid.NewGuid(),
                GenreId = Guid.NewGuid()
            },
            new Anime
            {
                Id = Guid.NewGuid(),
                Title = "A Silent Voice",
                AnimePic = File.ReadAllBytes(Path.Combine(imagesFolder, "quizzes", "silentvoice.jpg")),
                Description = "A heartfelt story of redemption and friendship as Shoya, a former bully, seeks forgiveness from Shoko, a deaf girl he tormented. Together, they navigate healing and self-discovery.",
                Episodes = 1,
                Seasons = 1,
                ReleaseDate = new DateTime(2016, 9, 17),
                StillOngoing = false,
                Rating = Rating.Great,
                WriterId = Guid.NewGuid(),
                StudioId = Guid.NewGuid(),
                GenreId = Guid.NewGuid()
            },
            new Anime
            {
                Id = Guid.NewGuid(),
                Title = "Your Name",
                AnimePic = File.ReadAllBytes(Path.Combine(imagesFolder, "quizzes", "yourname.jpg")),
                Description = "A breathtaking tale of two strangers, Taki and Mitsuha, who mysteriously swap lives. As they traverse through time and distance, they uncover a cosmic connection and a love that transcends worlds.",
                Episodes = 1,
                Seasons = 1,
                ReleaseDate = new DateTime(2016, 8, 26),
                StillOngoing = false,
                Rating = Rating.Excellent,
                WriterId = Guid.NewGuid(),
                StudioId = Guid.NewGuid(),
                GenreId = Guid.NewGuid()
            }
        };

        private Mock<IRepository<Anime, Guid>> _animeRepo;
        private IAnimeService _animeService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            AutoMapperConfig.RegisterMappings(typeof(QuizCardViewModel).Assembly);
        }

        [SetUp]
        public void Setup()
        {
            _animeRepo = new Mock<IRepository<Anime, Guid>>();
            _animeService = new AnimeService(_animeRepo.Object);
        }

        [Test]
        public async Task AssertThatGetAllAnimesWorksCorrectly()
        {
            IQueryable<Anime> animeMockQueryable = animesData.BuildMock();

            _animeRepo
                .Setup(r => r.GetAllAttached())
                .Returns(animeMockQueryable);

            List<AnimeLongCardViewModel> allAnimesActual = await _animeService
                .GetAllAnimes();

            Assert.IsNotNull(allAnimesActual);
            Assert.AreEqual(animesData.Count(), allAnimesActual.Count());

            allAnimesActual = allAnimesActual
                .OrderBy(m => m.Id)
                .ToList();

            int i = 0;
            foreach (AnimeLongCardViewModel returnedAnime in allAnimesActual)
            {
                Assert.AreEqual(this.animesData.OrderBy(m => m.Id).ToList()[i++].Id.ToString(), returnedAnime.Id.ToString());
            }
        }

        [Test]
        public async Task GetDetailedAnimeInfo_ValidId_ReturnsAnimeDetails()
        {
            Guid animeId = animesData.FirstOrDefault()!.Id;
            Anime anime = animesData.FirstOrDefault()!;

            _animeRepo
                .Setup(r => r.GetByIdAsync(animeId))
                .ReturnsAsync(anime);

            var result = await _animeService.GetDetailedAnimeInfo(animeId.ToString());

            Assert.IsNotNull(result);
            Assert.AreEqual(anime.Seasons, result.Seasons);
            Assert.AreEqual(anime.Title, result.Title);
            Assert.AreEqual(anime.Description, result.Description);
        }

        [Test]
        public void GetDetailedAnimeInfo_InvalidId_ThrowsException()
        {
            var invalidAnimeId = "invalid-guid";

            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await _animeService.GetDetailedAnimeInfo(invalidAnimeId)
            );

            Assert.AreEqual("There is no such anime", ex.Message);
        }

        [Test]
        public void GetDetailedAnimeInfo_AnimeNotFound_ThrowsException()
        {
            var nonExistentAnimeId = Guid.NewGuid();

            _animeRepo
                .Setup(r => r.GetByIdAsync(nonExistentAnimeId))
                .ReturnsAsync((Anime)null);

            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await _animeService.GetDetailedAnimeInfo(nonExistentAnimeId.ToString())
            );

            Assert.AreEqual("There is no such anime", ex.Message);
        }
    }
}