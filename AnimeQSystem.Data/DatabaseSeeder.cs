using AnimeQSystem.Data.Models;
using AnimeQSystem.Data.Models.AnimeSystem;
using AnimeQSystem.Data.Models.Enums;
using AnimeQSystem.Data.Models.QuizSystem;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AnimeQSystem.Data
{
    public static class DatabaseSeeder
    {
        public static async Task MigrateAndSeed(IServiceProvider serviceProvider)
        {
            string imagesFolder = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\wwwroot\images"));

            using var scope = serviceProvider.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Always migrate DB on application start
            await dbContext.Database.MigrateAsync();

            #region Seed users

            string johndoeIdentityUserId = Guid.NewGuid().ToString();
            string janesmithIdentityUserId = Guid.NewGuid().ToString();
            string alexjohnsonIdentityUserId = Guid.NewGuid().ToString();

            Guid johndoeUserId = Guid.NewGuid();
            Guid janesmithUserId = Guid.NewGuid();
            Guid alexjohnsonUserId = Guid.NewGuid();

            if (!userManager.Users.Any())
            {
                var password = "Test1234!"; // Your plain-text password

                var johndoeUser = new IdentityUser
                {
                    Id = johndoeIdentityUserId,
                    UserName = "johndoe@example.com",
                    Email = "johndoe@example.com",
                    EmailConfirmed = true
                };

                var janesmithUser = new IdentityUser
                {
                    Id = janesmithIdentityUserId,
                    UserName = "janesmith@example.com",
                    Email = "janesmith@example.com",
                    EmailConfirmed = true
                };

                var alexjohnsonUser = new IdentityUser
                {
                    Id = alexjohnsonIdentityUserId,
                    UserName = "alexjohnson@example.com",
                    Email = "alexjohnson@example.com",
                    EmailConfirmed = true
                };

                List<IdentityUser> identityUsers = new List<IdentityUser>()
                {
                    johndoeUser,
                    janesmithUser,
                    alexjohnsonUser
                };

                foreach (var user in identityUsers)
                {
                    await userManager.CreateAsync(user, password);
                }
            }

            // Seed the related Users (if you want the relationship)
            if (!dbContext.Users.Any())
            {
                await dbContext.Users.AddRangeAsync(
                    new User
                    {
                        Id = johndoeUserId,
                        FirstName = "John",
                        LastName = "Doe",
                        Age = 25,
                        Gender = Gender.Male,
                        Points = 1200,
                        CreatedAt = DateTime.Now,
                        LastModified = DateTime.Now,
                        IsDeleted = false,
                        ProfilePic = File.ReadAllBytes(Path.Combine(imagesFolder, "users", "johndoe.jpg")),
                        Country = "USA",
                        IdentityUserId = johndoeIdentityUserId
                    },
                    new User
                    {
                        Id = janesmithUserId,
                        FirstName = "Jane",
                        LastName = "Smith",
                        Age = 30,
                        Gender = Gender.Female,
                        Points = 1500,
                        CreatedAt = DateTime.Now,
                        LastModified = DateTime.Now,
                        IsDeleted = false,
                        ProfilePic = File.ReadAllBytes(Path.Combine(imagesFolder, "users", "janesmith.jpg")),
                        Country = "Canada",
                        IdentityUserId = janesmithIdentityUserId
                    },
                    new User
                    {
                        Id = alexjohnsonUserId,
                        FirstName = "Alex",
                        LastName = "Johnson",
                        Age = 22,
                        Gender = Gender.Other,
                        Points = 800,
                        CreatedAt = DateTime.Now,
                        LastModified = DateTime.Now,
                        IsDeleted = false,
                        ProfilePic = File.ReadAllBytes(Path.Combine(imagesFolder, "users", "alexjohnson.jpg")),
                        Country = "UK",
                        IdentityUserId = alexjohnsonIdentityUserId
                    }
                );
            }

            #endregion

            #region Seed other entities
            // Hardcoded GUIDs for genres
            Guid fantasyGenreId = Guid.NewGuid();
            Guid dramaGenreId = Guid.NewGuid();
            Guid romanceGenreId = Guid.NewGuid();
            Guid adventureGenreId = Guid.NewGuid();
            Guid sliceOfLifeGenreId = Guid.NewGuid();

            // Hardcoded GUIDs for studios
            Guid studioGhibliId = Guid.NewGuid();
            Guid kyotoAnimationId = Guid.NewGuid();
            Guid coMixWaveFilmsId = Guid.NewGuid();
            Guid tohoAnimationId = Guid.NewGuid();
            Guid madhouseId = Guid.NewGuid();

            // Hardcoded GUIDs for writers
            Guid hayaoMiyazakiId = Guid.NewGuid();
            Guid naokoYamadaId = Guid.NewGuid();
            Guid makotoShinkaiId = Guid.NewGuid();

            // Hardcoded GUIDs for animes
            Guid spiritedAwayId = Guid.NewGuid();
            Guid silentVoiceId = Guid.NewGuid();
            Guid yourNameId = Guid.NewGuid();

            // Hardcoded GUIDs for quizzes
            Guid spiritedAwayQuizId = Guid.NewGuid();
            Guid silentVoiceQuizId = Guid.NewGuid();
            Guid yourNameQuizId = Guid.NewGuid();

            // Hardcoded GUIDs for characters
            Guid chihiroOginoId = Guid.NewGuid();
            Guid shouyaIshidaId = Guid.NewGuid();
            Guid mitsuhaMiyamizuId = Guid.NewGuid();
            Guid hakuId = Guid.NewGuid();
            Guid noFaceId = Guid.NewGuid();
            Guid shokoNishimiyaId = Guid.NewGuid();
            Guid takiId = Guid.NewGuid();

            // Seed genres
            if (!dbContext.Genres.Any())
            {
                await dbContext.Genres.AddRangeAsync(
                    new Genre { Id = fantasyGenreId, Name = "Fantasy", Description = "Magical worlds and imaginative storytelling." },
                    new Genre { Id = dramaGenreId, Name = "Drama", Description = "Emotionally intense and story-driven." },
                    new Genre { Id = romanceGenreId, Name = "Romance", Description = "Love and relationships." },
                    new Genre { Id = adventureGenreId, Name = "Adventure", Description = "Exciting journeys and discoveries." },
                    new Genre { Id = sliceOfLifeGenreId, Name = "Slice of Life", Description = "Everyday life experiences." }
                );
            }

            // Seed studios
            if (!dbContext.Studios.Any())
            {
                await dbContext.Studios.AddRangeAsync(
                    new Studio { Id = studioGhibliId, Name = "Studio Ghibli", DateFounded = new DateTime(1985, 6, 15) },
                    new Studio { Id = kyotoAnimationId, Name = "Kyoto Animation", DateFounded = new DateTime(1981, 11, 7) },
                    new Studio { Id = coMixWaveFilmsId, Name = "CoMix Wave Films", DateFounded = new DateTime(2007, 3, 6) },
                    new Studio { Id = tohoAnimationId, Name = "Toho Animation", DateFounded = new DateTime(1956, 1, 1) },
                    new Studio { Id = madhouseId, Name = "Madhouse", DateFounded = new DateTime(1972, 10, 1) }
                );
            }

            // Seed writers
            if (!dbContext.Writers.Any())
            {
                await dbContext.Writers.AddRangeAsync(
                    new Writer { Id = hayaoMiyazakiId, FirstName = "Hayao", LastName = "Miyazaki", DateOfBirth = new DateTime(1941, 1, 5), FavoriteGenreId = fantasyGenreId },
                    new Writer { Id = naokoYamadaId, FirstName = "Naoko", LastName = "Yamada", DateOfBirth = new DateTime(1981, 5, 3), FavoriteGenreId = fantasyGenreId },
                    new Writer { Id = makotoShinkaiId, FirstName = "Makoto", LastName = "Shinkai", DateOfBirth = new DateTime(1973, 2, 9), FavoriteGenreId = romanceGenreId }
                );
            }

            // Update Anime Seed to link Writer to Anime
            if (!dbContext.Animes.Any())
            {
                await dbContext.Animes.AddRangeAsync(
                    new Anime
                    {
                        Id = spiritedAwayId,
                        Title = "Spirited Away",
                        AnimePic = File.ReadAllBytes(Path.Combine(imagesFolder, "quizzes", "spiritedaway.jpg")),
                        Description = "Chihiro, a young girl, finds herself trapped in a magical realm ruled by spirits and gods. As she fights to rescue her parents and return home, she discovers courage, compassion, and the value of identity.",
                        Episodes = 1,
                        Seasons = 1,
                        ReleaseDate = new DateTime(2001, 7, 20),
                        StillOngoing = false,
                        Rating = Rating.Excellent,
                        WriterId = hayaoMiyazakiId,
                        StudioId = studioGhibliId,
                        GenreId = fantasyGenreId
                    },
                    new Anime
                    {
                        Id = silentVoiceId,
                        Title = "A Silent Voice",
                        AnimePic = File.ReadAllBytes(Path.Combine(imagesFolder, "quizzes", "silentvoice.jpg")),
                        Description = "A heartfelt story of redemption and friendship as Shoya, a former bully, seeks forgiveness from Shoko, a deaf girl he tormented. Together, they navigate healing and self-discovery.",
                        Episodes = 1,
                        Seasons = 1,
                        ReleaseDate = new DateTime(2016, 9, 17),
                        StillOngoing = false,
                        Rating = Rating.Great,
                        WriterId = naokoYamadaId,
                        StudioId = kyotoAnimationId,
                        GenreId = dramaGenreId
                    },
                    new Anime
                    {
                        Id = yourNameId,
                        Title = "Your Name",
                        AnimePic = File.ReadAllBytes(Path.Combine(imagesFolder, "quizzes", "yourname.jpg")),
                        Description = "A breathtaking tale of two strangers, Taki and Mitsuha, who mysteriously swap lives. As they traverse through time and distance, they uncover a cosmic connection and a love that transcends worlds.",
                        Episodes = 1,
                        Seasons = 1,
                        ReleaseDate = new DateTime(2016, 8, 26),
                        StillOngoing = false,
                        Rating = Rating.Excellent,
                        WriterId = makotoShinkaiId,
                        StudioId = coMixWaveFilmsId,
                        GenreId = romanceGenreId
                    }
                );
            }

            // Seed characters
            if (!dbContext.Characters.Any())
            {
                await dbContext.Characters.AddRangeAsync(
                new Character { Id = chihiroOginoId, FirstName = "Chihiro", LastName = "Ogino", AnimeId = spiritedAwayId, Skill = "Being happy" },
                new Character { Id = hakuId, FirstName = "Haku", AnimeId = spiritedAwayId, Skill = "Turn into Dragon" },
                new Character { Id = noFaceId, FirstName = "No-Face", AnimeId = spiritedAwayId, Skill = "Making gold" },
                new Character { Id = shokoNishimiyaId, FirstName = "Shoko", LastName = "Nishimiya", AnimeId = silentVoiceId, Skill = "Sign language" },
                new Character { Id = shouyaIshidaId, FirstName = "Shoya", LastName = "Ishida", AnimeId = silentVoiceId, Skill = "Cute smile" },
                new Character { Id = mitsuhaMiyamizuId, FirstName = "Mitsuha", LastName = "Miyamizu", AnimeId = yourNameId, Skill = "Get back in time" },
                new Character { Id = takiId, FirstName = "Taki", LastName = "Tachibana", AnimeId = yourNameId, Skill = "Get back in time" }
            );
            }

            // Seed quizzes for each anime
            if (!dbContext.Quizzes.Any())
            {
                await dbContext.Quizzes.AddRangeAsync(
                    new Quiz
                    {
                        Id = spiritedAwayQuizId,
                        Title = "Spirited Away Quiz",
                        Description = "Test your knowledge about Spirited Away.",
                        CreatedAt = DateTime.Now,
                        CreatorId = johndoeUserId,
                        RewardPoints = 100,
                        Image = File.ReadAllBytes(Path.Combine(imagesFolder, "quizzes", "spiritedaway.jpg"))
                    },
                    new Quiz
                    {
                        Id = silentVoiceQuizId,
                        Title = "A Silent Voice Quiz",
                        Description = "Test your knowledge about A Silent Voice.",
                        CreatedAt = DateTime.Now,
                        CreatorId = alexjohnsonUserId,
                        RewardPoints = 100,
                        Image = File.ReadAllBytes(Path.Combine(imagesFolder, "quizzes", "silentvoice.jpg"))
                    },
                    new Quiz
                    {
                        Id = yourNameQuizId,
                        Title = "Your Name Quiz",
                        Description = "Test your knowledge about Your Name.",
                        CreatedAt = DateTime.Now,
                        CreatorId = janesmithUserId,
                        RewardPoints = 100,
                        Image = File.ReadAllBytes(Path.Combine(imagesFolder, "quizzes", "yourname.jpg"))
                    }
                );
            }

            Guid spiritedAwayQuestion1 = Guid.NewGuid();
            Guid spiritedAwayQuestion2 = Guid.NewGuid();
            Guid spiritedAwayQuestion3 = Guid.NewGuid();
            Guid spiritedAwayQuestion4 = Guid.NewGuid();
            Guid silentVoiceQuestion1 = Guid.NewGuid();
            Guid silentVoiceQuestion2 = Guid.NewGuid();
            Guid silentVoiceQuestion3 = Guid.NewGuid();
            Guid yourNameQuestion1 = Guid.NewGuid();
            Guid yourNameQuestion2 = Guid.NewGuid();

            if (!dbContext.QuizQuestions.Any())
            {
                await dbContext.QuizQuestions.AddRangeAsync(
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
                );
            }

            if (!dbContext.QuizOptions.Any())
            {
                await dbContext.QuizOptions.AddRangeAsync(
                    // Options for Spirited Away Quiz
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
                );

            }
            #endregion

            await dbContext.SaveChangesAsync();
        }
    }
}
