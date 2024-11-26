using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AnimeQSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateFounded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", maxLength: 120, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Writers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: true),
                    HairColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FavoriteGenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Writers_Genres_FavoriteGenreId",
                        column: x => x.FavoriteGenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RewardPoints = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quizzes_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Episodes = table.Column<int>(type: "int", nullable: false),
                    Seasons = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StillOngoing = table.Column<bool>(type: "bit", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    WriterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animes_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animes_Studios_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animes_Writers_WriterId",
                        column: x => x.WriterId,
                        principalTable: "Writers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuizType = table.Column<int>(type: "int", nullable: false),
                    QuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizQuestions_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizzesUsers",
                columns: table => new
                {
                    QuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizzesUsers", x => new { x.UserId, x.QuizId });
                    table.ForeignKey(
                        name: "FK_QuizzesUsers_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizzesUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", maxLength: 100000, nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    HairColor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsMainCharacter = table.Column<bool>(type: "bit", nullable: false),
                    Skill = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Weapon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Weakness = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AnimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    QuizQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizOptions_QuizQuestions_QuizQuestionId",
                        column: x => x.QuizQuestionId,
                        principalTable: "QuizQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2c975070-77f2-433d-a877-b6dca94eae24", 0, "a7de89d0-808b-4a14-a4ce-5085fa9fc059", "alexjohnson@example.com", true, false, null, "ALEXJOHNSON@EXAMPLE.COM", "ALEXJOHNSON", "AQAAAAIAAYagAAAAEHWVN8ToEC6lRJsTcVq/P4q4dtCmhAalhJQ3WxtCjT0kElVNR1Wcv+fYNyTP5B1AMQ==", null, false, "ac680fe1-6cd3-462d-9cf4-6a3924e78cbc", false, "alexjohnson" },
                    { "4fe8827a-ec44-4930-84c6-ef1392bc4b15", 0, "2cf0c601-76bf-4a32-9856-f7915283783e", "johndoe@example.com", true, false, null, "JOHNDOE@EXAMPLE.COM", "JOHNDOE", "AQAAAAIAAYagAAAAEMavNXV1kv6aXjMOFKtCXBmKHt2FLyGJjrN745oRpFOoAnNkJ6yQdLJuhSMk2J8c7g==", null, false, "f22f2583-a5cc-4155-92c0-9082cf64cdca", false, "johndoe" },
                    { "f80623e1-5be8-4f52-8995-18610b7a3ac6", 0, "e83ff8fb-f8a5-4d47-9332-471af3998ff3", "janesmith@example.com", true, false, null, "JANESMITH@EXAMPLE.COM", "JANESMITH", "AQAAAAIAAYagAAAAEIeF3EwWWdXTUnUHcoC237wRtxUWpzmEKaRpZOh/bkfmwA6EnSsyFYNcVeQIxkd70g==", null, false, "94f7d2f3-70a7-4872-9531-798f30b8ac00", false, "janesmith" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("58764574-5503-4df2-875c-aabce5c9b812"), "Emotionally intense and story-driven.", "Drama" },
                    { new Guid("6995299f-a1e8-4a98-a667-6dffa8b7043c"), "Exciting journeys and discoveries.", "Adventure" },
                    { new Guid("6ad70890-0a8b-4c9b-bb8b-7460ecd82bd2"), "Love and relationships.", "Romance" },
                    { new Guid("bd178283-ea78-4f9c-bfc9-d89477285329"), "Everyday life experiences.", "Slice of Life" },
                    { new Guid("cd24a8ef-51e6-41e4-b680-3c805ce7b3fc"), "Magical worlds and imaginative storytelling.", "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "Studios",
                columns: new[] { "Id", "DateFounded", "Name" },
                values: new object[,]
                {
                    { new Guid("00bf10d5-4e17-41ff-a7a7-fa09ead46725"), new DateTime(1981, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kyoto Animation" },
                    { new Guid("25673303-ddf8-436f-891f-f41d60480b93"), new DateTime(2007, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "CoMix Wave Films" },
                    { new Guid("90dc3d4a-9669-4b79-bbe3-e98ec923d660"), new DateTime(1985, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Studio Ghibli" },
                    { new Guid("e829851e-a21f-4368-a98f-4c57b6d1756b"), new DateTime(1972, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Madhouse" },
                    { new Guid("ec20a4c9-cf8c-4513-814f-f0dac802c8e5"), new DateTime(1956, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toho Animation" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Country", "CreatedAt", "FirstName", "Gender", "IdentityUserId", "IsDeleted", "LastModified", "LastName", "Points" },
                values: new object[,]
                {
                    { new Guid("11a9a1fd-3d87-4959-895f-976676ecaa9e"), 30, "Canada", new DateTime(2024, 11, 26, 9, 30, 38, 322, DateTimeKind.Local).AddTicks(5467), "Jane", 1, "f80623e1-5be8-4f52-8995-18610b7a3ac6", false, new DateTime(2024, 11, 26, 9, 30, 38, 322, DateTimeKind.Local).AddTicks(5469), "Smith", 1500 },
                    { new Guid("1edeaa7d-d8c0-41b3-bc7d-d0024b77e944"), 22, "UK", new DateTime(2024, 11, 26, 9, 30, 38, 322, DateTimeKind.Local).AddTicks(5486), "Alex", 2, "2c975070-77f2-433d-a877-b6dca94eae24", false, new DateTime(2024, 11, 26, 9, 30, 38, 322, DateTimeKind.Local).AddTicks(5488), "Johnson", 800 },
                    { new Guid("e15483f1-feaf-4a27-89a5-c1e6c7c00f3f"), 25, "USA", new DateTime(2024, 11, 26, 9, 30, 38, 322, DateTimeKind.Local).AddTicks(5448), "John", 0, "4fe8827a-ec44-4930-84c6-ef1392bc4b15", false, new DateTime(2024, 11, 26, 9, 30, 38, 322, DateTimeKind.Local).AddTicks(5449), "Doe", 1200 }
                });

            migrationBuilder.InsertData(
                table: "Writers",
                columns: new[] { "Id", "DateOfBirth", "FavoriteGenreId", "FirstName", "Gender", "HairColor", "Height", "LastName" },
                values: new object[,]
                {
                    { new Guid("4795ae85-3aa5-4ff5-b955-ed23ade08009"), new DateTime(1981, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cd24a8ef-51e6-41e4-b680-3c805ce7b3fc"), "Naoko", null, null, null, "Yamada" },
                    { new Guid("9a70d51d-8e5b-49e0-9cdf-59654265fe8e"), new DateTime(1941, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cd24a8ef-51e6-41e4-b680-3c805ce7b3fc"), "Hayao", null, null, null, "Miyazaki" },
                    { new Guid("c02e5d86-09b1-4360-b028-0d458eaed72a"), new DateTime(1973, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6ad70890-0a8b-4c9b-bb8b-7460ecd82bd2"), "Makoto", null, null, null, "Shinkai" }
                });

            migrationBuilder.InsertData(
                table: "Animes",
                columns: new[] { "Id", "Episodes", "GenreId", "Rating", "ReleaseDate", "Seasons", "StillOngoing", "StudioId", "Title", "WriterId" },
                values: new object[,]
                {
                    { new Guid("11b19f8e-d2a6-45ac-bff3-b655c79bfe90"), 1, new Guid("cd24a8ef-51e6-41e4-b680-3c805ce7b3fc"), 5, new DateTime(2001, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, new Guid("90dc3d4a-9669-4b79-bbe3-e98ec923d660"), "Spirited Away", new Guid("9a70d51d-8e5b-49e0-9cdf-59654265fe8e") },
                    { new Guid("68df0528-247a-4576-b1b0-386e5d0c8410"), 1, new Guid("58764574-5503-4df2-875c-aabce5c9b812"), 4, new DateTime(2016, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, new Guid("00bf10d5-4e17-41ff-a7a7-fa09ead46725"), "A Silent Voice", new Guid("4795ae85-3aa5-4ff5-b955-ed23ade08009") },
                    { new Guid("6b6a5c63-6514-43e2-a1af-ef691d53fdb4"), 1, new Guid("6ad70890-0a8b-4c9b-bb8b-7460ecd82bd2"), 5, new DateTime(2016, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, new Guid("25673303-ddf8-436f-891f-f41d60480b93"), "Your Name", new Guid("c02e5d86-09b1-4360-b028-0d458eaed72a") }
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "CreatedAt", "CreatorId", "Description", "ImageUrl", "RewardPoints", "Title" },
                values: new object[,]
                {
                    { new Guid("4d6be2f6-2763-4f64-ad00-535b7f3918c3"), new DateTime(2024, 11, 26, 9, 30, 38, 322, DateTimeKind.Local).AddTicks(7370), new Guid("11a9a1fd-3d87-4959-895f-976676ecaa9e"), "Test your knowledge about Your Name.", "https://images4.alphacoders.com/687/687987.jpg", 100, "Your Name Quiz" },
                    { new Guid("70bd26b1-9522-4391-844f-3039a0080707"), new DateTime(2024, 11, 26, 9, 30, 38, 322, DateTimeKind.Local).AddTicks(7325), new Guid("1edeaa7d-d8c0-41b3-bc7d-d0024b77e944"), "Test your knowledge about A Silent Voice.", "https://lwlies.com/wp-content/uploads/2017/03/a-silent-voice.jpg", 100, "A Silent Voice Quiz" },
                    { new Guid("e5252b94-99cb-4d2c-bdba-730e079f1b46"), new DateTime(2024, 11, 26, 9, 30, 38, 322, DateTimeKind.Local).AddTicks(7300), new Guid("e15483f1-feaf-4a27-89a5-c1e6c7c00f3f"), "Test your knowledge about Spirited Away.", "https://images2.alphacoders.com/131/1311453.jpg", 100, "Spirited Away Quiz" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Age", "AnimeId", "FirstName", "Gender", "HairColor", "Height", "IsMainCharacter", "LastName", "Skill", "Weakness", "Weapon" },
                values: new object[,]
                {
                    { new Guid("13e5faa2-ff28-4e0f-b4a2-9b820428d315"), null, new Guid("68df0528-247a-4576-b1b0-386e5d0c8410"), "Shoya", null, null, null, false, "Ishida", "Cute smile", null, null },
                    { new Guid("5a2f88cc-244c-421d-8b7a-01d0e41245e9"), null, new Guid("11b19f8e-d2a6-45ac-bff3-b655c79bfe90"), "Haku", null, null, null, false, null, "Turn into Dragon", null, null },
                    { new Guid("6f3aa06f-e28f-495e-953d-7ba1db6ccd75"), null, new Guid("11b19f8e-d2a6-45ac-bff3-b655c79bfe90"), "Chihiro", null, null, null, false, "Ogino", "Being happy", null, null },
                    { new Guid("909323df-3e18-431d-966c-8fbc7e4adf5a"), null, new Guid("6b6a5c63-6514-43e2-a1af-ef691d53fdb4"), "Mitsuha", null, null, null, false, "Miyamizu", "Get back in time", null, null },
                    { new Guid("a775555a-43ad-4698-aa52-eab4ee3d531f"), null, new Guid("6b6a5c63-6514-43e2-a1af-ef691d53fdb4"), "Taki", null, null, null, false, "Tachibana", "Get back in time", null, null },
                    { new Guid("b74ff1da-84ea-48da-b1a2-75dd6515ef7e"), null, new Guid("11b19f8e-d2a6-45ac-bff3-b655c79bfe90"), "No-Face", null, null, null, false, null, "Making gold", null, null },
                    { new Guid("cd719eac-043f-4781-8a2f-c8902440a660"), null, new Guid("68df0528-247a-4576-b1b0-386e5d0c8410"), "Shoko", null, null, null, false, "Nishimiya", "Sign language", null, null }
                });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "Answer", "QuizId", "QuizType", "Title" },
                values: new object[,]
                {
                    { new Guid("19aad344-5c26-4975-856a-bd140fe59eb6"), null, new Guid("4d6be2f6-2763-4f64-ad00-535b7f3918c3"), 1, "What is the name of the main character in Your Name?" },
                    { new Guid("33412239-3665-473a-8a31-8993b6757df8"), "Her real name", new Guid("e5252b94-99cb-4d2c-bdba-730e079f1b46"), 2, "What does Chihiro need to remember to return home?" },
                    { new Guid("4ee65c37-908c-4984-8637-15cf8366c841"), null, new Guid("e5252b94-99cb-4d2c-bdba-730e079f1b46"), 1, "Who runs the bathhouse in Spirited Away?" },
                    { new Guid("4ff011c9-db76-4b08-be6c-8d2fa5eff019"), null, new Guid("70bd26b1-9522-4391-844f-3039a0080707"), 1, "What is the name of the main protagonist in A Silent Voice?" },
                    { new Guid("52a5049e-3930-41e6-80b5-7eb2b5cc0c4e"), null, new Guid("e5252b94-99cb-4d2c-bdba-730e079f1b46"), 1, "What is the name of the main protagonist in Spirited Away?" },
                    { new Guid("9c962226-8435-494e-ba81-86c9c5ac09c1"), "True", new Guid("70bd26b1-9522-4391-844f-3039a0080707"), 0, "True or False: Shoya Ishida is a former bully in A Silent Voice." },
                    { new Guid("a33498f4-0f90-41b8-b480-f144c2554cca"), "True", new Guid("4d6be2f6-2763-4f64-ad00-535b7f3918c3"), 0, "True or False: Taki and Mitsuha swap bodies in Your Name." },
                    { new Guid("a782caf2-4528-4bff-9cb9-ae1042381e05"), "Shoko Nishimiya", new Guid("70bd26b1-9522-4391-844f-3039a0080707"), 2, "Who does Shoya Ishida try to make amends with?" },
                    { new Guid("fee6e0f3-fdb5-4de8-9ee3-8de18062e9a9"), "False", new Guid("e5252b94-99cb-4d2c-bdba-730e079f1b46"), 0, "True or False: No-Face is a spirit who tries to eat Chihiro." }
                });

            migrationBuilder.InsertData(
                table: "QuizOptions",
                columns: new[] { "Id", "IsCorrect", "OptionText", "QuizQuestionId" },
                values: new object[,]
                {
                    { new Guid("1790a652-b190-4505-95e3-d755fbc68d3d"), true, "Chihiro Ogino", new Guid("52a5049e-3930-41e6-80b5-7eb2b5cc0c4e") },
                    { new Guid("24548a3c-a676-43c8-b95e-3d0aa10088a5"), true, "Yubaba", new Guid("4ee65c37-908c-4984-8637-15cf8366c841") },
                    { new Guid("283da678-50b2-45b4-b151-2586e0172e8b"), false, "Sophie Hatter", new Guid("52a5049e-3930-41e6-80b5-7eb2b5cc0c4e") },
                    { new Guid("304a1fac-b68a-438c-a8c8-abcb99edd3a9"), false, "Taki Tachibana", new Guid("4ff011c9-db76-4b08-be6c-8d2fa5eff019") },
                    { new Guid("4ee6c801-d8b5-4add-bce9-f52b03ea7159"), false, "Haku", new Guid("4ee65c37-908c-4984-8637-15cf8366c841") },
                    { new Guid("546bb2e1-e801-497d-a560-432310e7e1b8"), false, "Shoya Ishida", new Guid("19aad344-5c26-4975-856a-bd140fe59eb6") },
                    { new Guid("55c56e9d-d909-4caf-b147-d85ff92c80b9"), false, "Nausicaä", new Guid("52a5049e-3930-41e6-80b5-7eb2b5cc0c4e") },
                    { new Guid("59d49a7a-45cf-4be4-9986-b889bd260ac3"), true, "Shoya Ishida", new Guid("4ff011c9-db76-4b08-be6c-8d2fa5eff019") },
                    { new Guid("a3540e4d-ecca-4c8a-a71d-ba6959b4d775"), false, "Zeniba", new Guid("4ee65c37-908c-4984-8637-15cf8366c841") },
                    { new Guid("ac072177-8960-449d-828c-ecb838fcc0b6"), true, "Mitsuha Miyamizu", new Guid("19aad344-5c26-4975-856a-bd140fe59eb6") },
                    { new Guid("b4154839-d774-4f63-b306-1982762d2d94"), false, "Chihiro Ogino", new Guid("19aad344-5c26-4975-856a-bd140fe59eb6") },
                    { new Guid("c0c20d80-14da-4adc-b4f2-9be816aaed3a"), false, "Mitsuha Miyamizu", new Guid("4ff011c9-db76-4b08-be6c-8d2fa5eff019") },
                    { new Guid("c5fd07cd-8948-4de5-8c93-d862b3f937a7"), false, "Shoko Nishimiya", new Guid("4ff011c9-db76-4b08-be6c-8d2fa5eff019") },
                    { new Guid("d1f06479-377d-42a3-b787-72945fc54e96"), true, "Taki Tachibana", new Guid("19aad344-5c26-4975-856a-bd140fe59eb6") },
                    { new Guid("d3ff0d95-4585-4e66-80bb-c69b0ac4f618"), false, "Satsuki Kusakabe", new Guid("52a5049e-3930-41e6-80b5-7eb2b5cc0c4e") },
                    { new Guid("ddd89920-7a42-4ccd-90e5-e89b81969d50"), false, "Kamaji", new Guid("4ee65c37-908c-4984-8637-15cf8366c841") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animes_GenreId",
                table: "Animes",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Animes_StudioId",
                table: "Animes",
                column: "StudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Animes_WriterId",
                table: "Animes",
                column: "WriterId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AnimeId",
                table: "Characters",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizOptions_QuizQuestionId",
                table: "QuizOptions",
                column: "QuizQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_QuizId",
                table: "QuizQuestions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_CreatorId",
                table: "Quizzes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizzesUsers_QuizId",
                table: "QuizzesUsers",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdentityUserId",
                table: "Users",
                column: "IdentityUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Writers_FavoriteGenreId",
                table: "Writers",
                column: "FavoriteGenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "QuizOptions");

            migrationBuilder.DropTable(
                name: "QuizzesUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Animes");

            migrationBuilder.DropTable(
                name: "QuizQuestions");

            migrationBuilder.DropTable(
                name: "Studios");

            migrationBuilder.DropTable(
                name: "Writers");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
