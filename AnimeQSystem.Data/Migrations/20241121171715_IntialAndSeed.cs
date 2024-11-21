using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AnimeQSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class IntialAndSeed : Migration
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
                    { "6b07025f-873b-4b01-84ed-a1248c27fb2a", 0, "224bf35b-ea89-43b0-8100-24c675d866ec", "alexjohnson@example.com", true, false, null, "ALEXJOHNSON@EXAMPLE.COM", "ALEXJOHNSON", "AQAAAAIAAYagAAAAELHuEOVSAeXgGe6t7FZBDpHZNQ57qibYVLS5tmISUT5+7vytimWyvCTwRqkCpPEWYQ==", null, false, "009818cc-0f87-4d96-98cc-31b2e57a1651", false, "alexjohnson" },
                    { "f0394f41-3421-48a9-bd2d-ee3cf0f706a9", 0, "e4e33082-cd82-48a6-992d-60fa1537fa7b", "janesmith@example.com", true, false, null, "JANESMITH@EXAMPLE.COM", "JANESMITH", "AQAAAAIAAYagAAAAEJUcVHIIOEH72zPaiPAWQn8IZR2BX0QteQgu0rkZxhWElPQ3NO3fRQ87VuOGP1+aNw==", null, false, "f18df274-5ba2-44c1-a1f9-ada8f4a7f563", false, "janesmith" },
                    { "f48ba418-31fc-4cc4-adda-5d6ae18d4ffa", 0, "a593e0f4-551b-42c8-9b57-781307ee9294", "johndoe@example.com", true, false, null, "JOHNDOE@EXAMPLE.COM", "JOHNDOE", "AQAAAAIAAYagAAAAEDE1sUjqRt0OcnIFr2Gkt6MIxp78Ycfndk6Mjd5x4DmawQlrZG/rnto376IY2ObMlw==", null, false, "fad93452-3a87-4309-8776-4d7907f65329", false, "johndoe" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("4b399db3-66c9-47c0-bbe4-9938c9c38466"), "Love and relationships.", "Romance" },
                    { new Guid("76b77f95-a441-4dbd-aa52-1343936236eb"), "Exciting journeys and discoveries.", "Adventure" },
                    { new Guid("bf17fef6-72a7-41fc-9a9b-5251123b02a0"), "Magical worlds and imaginative storytelling.", "Fantasy" },
                    { new Guid("c861e1a0-3a19-44b8-afc8-2eba56f9c700"), "Everyday life experiences.", "Slice of Life" },
                    { new Guid("d613b8c3-6023-4538-8727-9e01403b0a66"), "Emotionally intense and story-driven.", "Drama" }
                });

            migrationBuilder.InsertData(
                table: "Studios",
                columns: new[] { "Id", "DateFounded", "Name" },
                values: new object[,]
                {
                    { new Guid("218784ff-aa54-4439-919f-f05fc3210d40"), new DateTime(1981, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kyoto Animation" },
                    { new Guid("22354271-34e8-42e8-bd32-640f8853d975"), new DateTime(1985, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Studio Ghibli" },
                    { new Guid("3d4e1626-e4e9-47ba-be0a-e261a50c7c90"), new DateTime(2007, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "CoMix Wave Films" },
                    { new Guid("af2dfa37-e909-4eb2-9d6b-556877691db2"), new DateTime(1956, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toho Animation" },
                    { new Guid("b21bd6d0-c322-4322-b7f1-4e18a2c3b132"), new DateTime(1972, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Madhouse" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Country", "CreatedAt", "FirstName", "Gender", "IdentityUserId", "IsDeleted", "LastModified", "LastName", "Points" },
                values: new object[,]
                {
                    { new Guid("3d412158-0be7-415e-86fc-e5a6745b5d81"), 22, "UK", new DateTime(2024, 11, 21, 19, 17, 14, 277, DateTimeKind.Local).AddTicks(3943), "Alex", 2, "6b07025f-873b-4b01-84ed-a1248c27fb2a", false, new DateTime(2024, 11, 21, 19, 17, 14, 277, DateTimeKind.Local).AddTicks(3945), "Johnson", 800 },
                    { new Guid("501b2641-10d8-473a-8053-dde0487f32e6"), 25, "USA", new DateTime(2024, 11, 21, 19, 17, 14, 277, DateTimeKind.Local).AddTicks(3808), "John", 0, "f48ba418-31fc-4cc4-adda-5d6ae18d4ffa", false, new DateTime(2024, 11, 21, 19, 17, 14, 277, DateTimeKind.Local).AddTicks(3810), "Doe", 1200 },
                    { new Guid("cdef08bf-7968-4e48-8986-a38cbd4bd028"), 30, "Canada", new DateTime(2024, 11, 21, 19, 17, 14, 277, DateTimeKind.Local).AddTicks(3828), "Jane", 1, "f0394f41-3421-48a9-bd2d-ee3cf0f706a9", false, new DateTime(2024, 11, 21, 19, 17, 14, 277, DateTimeKind.Local).AddTicks(3830), "Smith", 1500 }
                });

            migrationBuilder.InsertData(
                table: "Writers",
                columns: new[] { "Id", "DateOfBirth", "FavoriteGenreId", "FirstName", "Gender", "HairColor", "Height", "LastName" },
                values: new object[,]
                {
                    { new Guid("77f46aac-1ba8-480a-9fac-e74c3aa30c01"), new DateTime(1981, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bf17fef6-72a7-41fc-9a9b-5251123b02a0"), "Naoko", null, null, null, "Yamada" },
                    { new Guid("9685aa54-aabf-4c6d-a1b1-bf5941034861"), new DateTime(1973, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4b399db3-66c9-47c0-bbe4-9938c9c38466"), "Makoto", null, null, null, "Shinkai" },
                    { new Guid("bcd3f42d-b7fb-4157-9f82-333f17f5d2ed"), new DateTime(1941, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bf17fef6-72a7-41fc-9a9b-5251123b02a0"), "Hayao", null, null, null, "Miyazaki" }
                });

            migrationBuilder.InsertData(
                table: "Animes",
                columns: new[] { "Id", "Episodes", "GenreId", "Rating", "ReleaseDate", "Seasons", "StillOngoing", "StudioId", "Title", "WriterId" },
                values: new object[,]
                {
                    { new Guid("0331ffb2-96a8-4eaf-be34-1a4682c1313a"), 1, new Guid("4b399db3-66c9-47c0-bbe4-9938c9c38466"), 5, new DateTime(2016, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, new Guid("3d4e1626-e4e9-47ba-be0a-e261a50c7c90"), "Your Name", new Guid("9685aa54-aabf-4c6d-a1b1-bf5941034861") },
                    { new Guid("b1ef98c2-eac2-471f-9506-16e213138f64"), 1, new Guid("d613b8c3-6023-4538-8727-9e01403b0a66"), 4, new DateTime(2016, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, new Guid("218784ff-aa54-4439-919f-f05fc3210d40"), "A Silent Voice", new Guid("77f46aac-1ba8-480a-9fac-e74c3aa30c01") },
                    { new Guid("d9d68329-bb49-4075-850d-2da01083f6b5"), 1, new Guid("bf17fef6-72a7-41fc-9a9b-5251123b02a0"), 5, new DateTime(2001, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, new Guid("22354271-34e8-42e8-bd32-640f8853d975"), "Spirited Away", new Guid("bcd3f42d-b7fb-4157-9f82-333f17f5d2ed") }
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "CreatedAt", "CreatorId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("2415e303-6dbb-4f09-8f81-0ef085101d5f"), new DateTime(2024, 11, 21, 19, 17, 14, 277, DateTimeKind.Local).AddTicks(5359), new Guid("cdef08bf-7968-4e48-8986-a38cbd4bd028"), "Test your knowledge about Your Name.", "Your Name Quiz" },
                    { new Guid("4a8a84a9-35da-4e5c-8a73-a36b1149e565"), new DateTime(2024, 11, 21, 19, 17, 14, 277, DateTimeKind.Local).AddTicks(5296), new Guid("501b2641-10d8-473a-8053-dde0487f32e6"), "Test your knowledge about Spirited Away.", "Spirited Away Quiz" },
                    { new Guid("b6ed8a74-be90-424c-b663-18829f5aaf28"), new DateTime(2024, 11, 21, 19, 17, 14, 277, DateTimeKind.Local).AddTicks(5351), new Guid("3d412158-0be7-415e-86fc-e5a6745b5d81"), "Test your knowledge about A Silent Voice.", "A Silent Voice Quiz" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Age", "AnimeId", "FirstName", "Gender", "HairColor", "Height", "IsMainCharacter", "LastName", "Skill", "Weakness", "Weapon" },
                values: new object[,]
                {
                    { new Guid("115fb0a9-518c-4346-994c-f50852105731"), null, new Guid("0331ffb2-96a8-4eaf-be34-1a4682c1313a"), "Taki", null, null, null, false, "Tachibana", "Get back in time", null, null },
                    { new Guid("19822615-8e5a-40f6-b367-45facb75dae3"), null, new Guid("d9d68329-bb49-4075-850d-2da01083f6b5"), "Haku", null, null, null, false, null, "Turn into Dragon", null, null },
                    { new Guid("2a919956-af57-4f75-90b7-fb816991e5ad"), null, new Guid("b1ef98c2-eac2-471f-9506-16e213138f64"), "Shoko", null, null, null, false, "Nishimiya", "Sign language", null, null },
                    { new Guid("43dcf69f-8d92-4a95-a38d-fdf28c45c981"), null, new Guid("d9d68329-bb49-4075-850d-2da01083f6b5"), "Chihiro", null, null, null, false, "Ogino", "Being happy", null, null },
                    { new Guid("853d6888-0fb3-4fa1-a4cd-5353d1a44561"), null, new Guid("b1ef98c2-eac2-471f-9506-16e213138f64"), "Shoya", null, null, null, false, "Ishida", "Cute smile", null, null },
                    { new Guid("96ef8413-a427-42d1-9b63-b48ce3cb9491"), null, new Guid("0331ffb2-96a8-4eaf-be34-1a4682c1313a"), "Mitsuha", null, null, null, false, "Miyamizu", "Get back in time", null, null },
                    { new Guid("98e6230d-f65c-44f4-a135-8f19641abf90"), null, new Guid("d9d68329-bb49-4075-850d-2da01083f6b5"), "No-Face", null, null, null, false, null, "Making gold", null, null }
                });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "Answer", "QuizId", "QuizType", "Title" },
                values: new object[,]
                {
                    { new Guid("197bc952-c537-4552-b034-7ebc3f8007fe"), "True", new Guid("b6ed8a74-be90-424c-b663-18829f5aaf28"), 0, "True or False: Shoya Ishida is a former bully in A Silent Voice." },
                    { new Guid("3961349f-35ed-4cfd-9420-b880c99a9cf4"), "Her real name", new Guid("4a8a84a9-35da-4e5c-8a73-a36b1149e565"), 2, "What does Chihiro need to remember to return home?" },
                    { new Guid("6ca2443b-008a-456b-ae28-6576bff2d8dc"), null, new Guid("2415e303-6dbb-4f09-8f81-0ef085101d5f"), 1, "What is the name of the main character in Your Name?" },
                    { new Guid("827b6e6a-81fe-4490-8e49-629fedb5b5b1"), "True", new Guid("2415e303-6dbb-4f09-8f81-0ef085101d5f"), 0, "True or False: Taki and Mitsuha swap bodies in Your Name." },
                    { new Guid("ab5a800a-f0aa-4ab5-9e39-e88c3d42cc83"), "False", new Guid("4a8a84a9-35da-4e5c-8a73-a36b1149e565"), 0, "True or False: No-Face is a spirit who tries to eat Chihiro." },
                    { new Guid("b5d4b633-d6b3-4f7f-b2ac-225c187f45b1"), null, new Guid("b6ed8a74-be90-424c-b663-18829f5aaf28"), 1, "What is the name of the main protagonist in A Silent Voice?" },
                    { new Guid("bee83cbd-697f-4a17-aa52-cc695fbb1e28"), "Shoko Nishimiya", new Guid("b6ed8a74-be90-424c-b663-18829f5aaf28"), 2, "Who does Shoya Ishida try to make amends with?" },
                    { new Guid("d33b97ff-9280-4377-9c83-cd361abcfa57"), null, new Guid("4a8a84a9-35da-4e5c-8a73-a36b1149e565"), 1, "Who runs the bathhouse in Spirited Away?" },
                    { new Guid("eed7f69b-d4a5-4283-b798-5075888da2aa"), null, new Guid("4a8a84a9-35da-4e5c-8a73-a36b1149e565"), 1, "What is the name of the main protagonist in Spirited Away?" }
                });

            migrationBuilder.InsertData(
                table: "QuizOptions",
                columns: new[] { "Id", "IsCorrect", "OptionText", "QuizQuestionId" },
                values: new object[,]
                {
                    { new Guid("044127ec-193f-4cb5-a994-efd6f51e6c48"), true, "Taki Tachibana", new Guid("6ca2443b-008a-456b-ae28-6576bff2d8dc") },
                    { new Guid("097ec670-a099-465b-8e58-fede9343728c"), false, "Kamaji", new Guid("d33b97ff-9280-4377-9c83-cd361abcfa57") },
                    { new Guid("131d2407-381d-4a67-a4be-02e6dae2b119"), false, "Taki Tachibana", new Guid("b5d4b633-d6b3-4f7f-b2ac-225c187f45b1") },
                    { new Guid("245aecb5-b9a2-4bbf-9c96-6be57ad3842c"), true, "Chihiro Ogino", new Guid("eed7f69b-d4a5-4283-b798-5075888da2aa") },
                    { new Guid("24d6706d-d4bd-4bc8-983d-537d569cd01c"), false, "Sophie Hatter", new Guid("eed7f69b-d4a5-4283-b798-5075888da2aa") },
                    { new Guid("563bb9f1-28aa-48e2-913b-4e49637e2892"), false, "Chihiro Ogino", new Guid("6ca2443b-008a-456b-ae28-6576bff2d8dc") },
                    { new Guid("64432bbe-2135-43cb-93b9-032fea8c7748"), false, "Zeniba", new Guid("d33b97ff-9280-4377-9c83-cd361abcfa57") },
                    { new Guid("7962a535-d683-4c81-9b6b-3100c2f5a2d7"), false, "Haku", new Guid("d33b97ff-9280-4377-9c83-cd361abcfa57") },
                    { new Guid("7d5a2d4a-6c0b-4f87-869c-bab5fbd8ee4c"), false, "Mitsuha Miyamizu", new Guid("b5d4b633-d6b3-4f7f-b2ac-225c187f45b1") },
                    { new Guid("8033a842-348a-4301-93b1-b0bb20ccda8a"), false, "Shoko Nishimiya", new Guid("b5d4b633-d6b3-4f7f-b2ac-225c187f45b1") },
                    { new Guid("98f2b3dd-6785-494c-80dd-899134476652"), true, "Mitsuha Miyamizu", new Guid("6ca2443b-008a-456b-ae28-6576bff2d8dc") },
                    { new Guid("aacb4c0b-bf9d-4a35-904d-7cfe29c6428d"), false, "Shoya Ishida", new Guid("6ca2443b-008a-456b-ae28-6576bff2d8dc") },
                    { new Guid("b240e627-cb7f-44a8-867b-658dceb3a09f"), false, "Nausicaä", new Guid("eed7f69b-d4a5-4283-b798-5075888da2aa") },
                    { new Guid("b50a5ccd-17fb-494f-b600-38ab9ca960e0"), true, "Shoya Ishida", new Guid("b5d4b633-d6b3-4f7f-b2ac-225c187f45b1") },
                    { new Guid("b6300004-e39d-4eb5-9758-ed1b65620d0a"), false, "Satsuki Kusakabe", new Guid("eed7f69b-d4a5-4283-b798-5075888da2aa") },
                    { new Guid("f403fdce-0946-42a8-aa3d-9ca8b7141e87"), true, "Yubaba", new Guid("d33b97ff-9280-4377-9c83-cd361abcfa57") }
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
