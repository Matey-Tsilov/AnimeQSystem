using AnimeQSystem.Data.Models;
using AnimeQSystem.Data.Models.AnimeSystem;
using AnimeQSystem.Data.Models.Enums;
using AnimeQSystem.Data.Models.QuizSystem;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AnimeQSystem.Data
{
    public static class DatabaseSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {

            #region Seed users
            var password = "Test1234!"; // Your plain-text password
            // Password hasher
            var passwordHasher = new PasswordHasher<IdentityUser>();
            // Creating an empty user object (it doesn't need any properties except for the password itself)
            var dummyUser = new IdentityUser();  // Just a dummy object to satisfy the PasswordHasher
            // Hash the password
            var hashedPassword = passwordHasher.HashPassword(dummyUser, password);

            string johndoeIdentityUserId = Guid.NewGuid().ToString();
            string janesmithIdentityUserId = Guid.NewGuid().ToString();
            string alexjohnsonIdentityUserId = Guid.NewGuid().ToString();

            Guid johndoeUserId = Guid.NewGuid();
            Guid janesmithUserId = Guid.NewGuid();
            Guid alexjohnsonUserId = Guid.NewGuid();

            var johndoeUser = new IdentityUser
            {
                Id = johndoeIdentityUserId,
                UserName = "johndoe",
                NormalizedUserName = "JOHNDOE",
                Email = "johndoe@example.com",
                NormalizedEmail = "JOHNDOE@EXAMPLE.COM",
                EmailConfirmed = true
            };
            johndoeUser.PasswordHash = passwordHasher.HashPassword(johndoeUser, password);

            var janesmithUser = new IdentityUser
            {
                Id = janesmithIdentityUserId,
                UserName = "janesmith",
                NormalizedUserName = "JANESMITH",
                Email = "janesmith@example.com",
                NormalizedEmail = "JANESMITH@EXAMPLE.COM",
                EmailConfirmed = true
            };
            janesmithUser.PasswordHash = passwordHasher.HashPassword(janesmithUser, password);

            var alexjohnsonUser = new IdentityUser
            {
                Id = alexjohnsonIdentityUserId,
                UserName = "alexjohnson",
                NormalizedUserName = "ALEXJOHNSON",
                Email = "alexjohnson@example.com",
                NormalizedEmail = "ALEXJOHNSON@EXAMPLE.COM",
                EmailConfirmed = true
            };
            alexjohnsonUser.PasswordHash = passwordHasher.HashPassword(alexjohnsonUser, password);

            modelBuilder.Entity<IdentityUser>().HasData(johndoeUser, janesmithUser, alexjohnsonUser);

            // Seed the related Users (if you want the relationship)
            modelBuilder.Entity<User>().HasData(
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
                    Country = "UK",
                    IdentityUserId = alexjohnsonIdentityUserId
                }
            );

            #endregion

            #region Seed other entities
            // Hardcoded GUIDs for genres
            var fantasyGenreId = Guid.NewGuid();
            var dramaGenreId = Guid.NewGuid();
            var romanceGenreId = Guid.NewGuid();
            var adventureGenreId = Guid.NewGuid();
            var sliceOfLifeGenreId = Guid.NewGuid();

            // Hardcoded GUIDs for studios
            var studioGhibliId = Guid.NewGuid();
            var kyotoAnimationId = Guid.NewGuid();
            var coMixWaveFilmsId = Guid.NewGuid();
            var tohoAnimationId = Guid.NewGuid();
            var madhouseId = Guid.NewGuid();

            // Hardcoded GUIDs for writers
            var hayaoMiyazakiId = Guid.NewGuid();
            var naokoYamadaId = Guid.NewGuid();
            var makotoShinkaiId = Guid.NewGuid();

            // Hardcoded GUIDs for animes
            var spiritedAwayId = Guid.NewGuid();
            var silentVoiceId = Guid.NewGuid();
            var yourNameId = Guid.NewGuid();

            // Hardcoded GUIDs for quizzes
            var spiritedAwayQuizId = Guid.NewGuid();
            var silentVoiceQuizId = Guid.NewGuid();
            var yourNameQuizId = Guid.NewGuid();

            // Hardcoded GUIDs for characters
            var chihiroOginoId = Guid.NewGuid();
            var shouyaIshidaId = Guid.NewGuid();
            var mitsuhaMiyamizuId = Guid.NewGuid();
            var hakuId = Guid.NewGuid();
            var noFaceId = Guid.NewGuid();
            var shokoNishimiyaId = Guid.NewGuid();
            var takiId = Guid.NewGuid();

            // Seed genres
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = fantasyGenreId, Name = "Fantasy", Description = "Magical worlds and imaginative storytelling." },
                new Genre { Id = dramaGenreId, Name = "Drama", Description = "Emotionally intense and story-driven." },
                new Genre { Id = romanceGenreId, Name = "Romance", Description = "Love and relationships." },
                new Genre { Id = adventureGenreId, Name = "Adventure", Description = "Exciting journeys and discoveries." },
                new Genre { Id = sliceOfLifeGenreId, Name = "Slice of Life", Description = "Everyday life experiences." }
            );

            // Seed studios
            modelBuilder.Entity<Studio>().HasData(
                new Studio { Id = studioGhibliId, Name = "Studio Ghibli", DateFounded = new DateTime(1985, 6, 15) },
                new Studio { Id = kyotoAnimationId, Name = "Kyoto Animation", DateFounded = new DateTime(1981, 11, 7) },
                new Studio { Id = coMixWaveFilmsId, Name = "CoMix Wave Films", DateFounded = new DateTime(2007, 3, 6) },
                new Studio { Id = tohoAnimationId, Name = "Toho Animation", DateFounded = new DateTime(1956, 1, 1) },
                new Studio { Id = madhouseId, Name = "Madhouse", DateFounded = new DateTime(1972, 10, 1) }
            );

            // Seed writers
            modelBuilder.Entity<Writer>().HasData(
                new Writer { Id = hayaoMiyazakiId, FirstName = "Hayao", LastName = "Miyazaki", DateOfBirth = new DateTime(1941, 1, 5), FavoriteGenreId = fantasyGenreId },
                new Writer { Id = naokoYamadaId, FirstName = "Naoko", LastName = "Yamada", DateOfBirth = new DateTime(1981, 5, 3), FavoriteGenreId = fantasyGenreId },
                new Writer { Id = makotoShinkaiId, FirstName = "Makoto", LastName = "Shinkai", DateOfBirth = new DateTime(1973, 2, 9), FavoriteGenreId = romanceGenreId }
            );

            // Update Anime Seed to link Writer to Anime
            modelBuilder.Entity<Anime>().HasData(
                new Anime
                {
                    Id = spiritedAwayId,
                    Title = "Spirited Away",
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

            // Seed characters
            modelBuilder.Entity<Character>().HasData(
                new Character { Id = chihiroOginoId, FirstName = "Chihiro", LastName = "Ogino", AnimeId = spiritedAwayId, Skill = "Being happy" },
                new Character { Id = hakuId, FirstName = "Haku", AnimeId = spiritedAwayId, Skill = "Turn into Dragon" },
                new Character { Id = noFaceId, FirstName = "No-Face", AnimeId = spiritedAwayId, Skill = "Making gold" },
                new Character { Id = shokoNishimiyaId, FirstName = "Shoko", LastName = "Nishimiya", AnimeId = silentVoiceId, Skill = "Sign language" },
                new Character { Id = shouyaIshidaId, FirstName = "Shoya", LastName = "Ishida", AnimeId = silentVoiceId, Skill = "Cute smile" },
                new Character { Id = mitsuhaMiyamizuId, FirstName = "Mitsuha", LastName = "Miyamizu", AnimeId = yourNameId, Skill = "Get back in time" },
                new Character { Id = takiId, FirstName = "Taki", LastName = "Tachibana", AnimeId = yourNameId, Skill = "Get back in time" }
            );

            // Seed quizzes for each anime
            modelBuilder.Entity<Quiz>().HasData(
                new Quiz
                {
                    Id = spiritedAwayQuizId,
                    Title = "Spirited Away Quiz",
                    Description = "Test your knowledge about Spirited Away.",
                    CreatedAt = DateTime.Now,
                    CreatorId = johndoeUserId
                },
                new Quiz
                {
                    Id = silentVoiceQuizId,
                    Title = "A Silent Voice Quiz",
                    Description = "Test your knowledge about A Silent Voice.",
                    CreatedAt = DateTime.Now,
                    CreatorId = alexjohnsonUserId
                },
                new Quiz
                {
                    Id = yourNameQuizId,
                    Title = "Your Name Quiz",
                    Description = "Test your knowledge about Your Name.",
                    CreatedAt = DateTime.Now,
                    CreatorId = janesmithUserId
                }
            );

            Guid spiritedAwayQuestion1 = Guid.NewGuid();
            Guid spiritedAwayQuestion2 = Guid.NewGuid();
            Guid spiritedAwayQuestion3 = Guid.NewGuid();
            Guid spiritedAwayQuestion4 = Guid.NewGuid();
            Guid silentVoiceQuestion1 = Guid.NewGuid();
            Guid silentVoiceQuestion2 = Guid.NewGuid();
            Guid silentVoiceQuestion3 = Guid.NewGuid();
            Guid yourNameQuestion1 = Guid.NewGuid();
            Guid yourNameQuestion2 = Guid.NewGuid();

            modelBuilder.Entity<QuizQuestion>().HasData(
                // Spirited Away Quiz Questions
                new QuizQuestion
                {
                    Id = spiritedAwayQuestion1,
                    Title = "What is the name of the main protagonist in Spirited Away?",
                    QuizType = QuizType.MultipleChoice,
                    QuizId = spiritedAwayQuizId
                },
                new QuizQuestion
                {
                    Id = spiritedAwayQuestion2,
                    Title = "Who runs the bathhouse in Spirited Away?",
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

            modelBuilder.Entity<QuizOption>().HasData(
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

            #endregion
        }
    }
}
