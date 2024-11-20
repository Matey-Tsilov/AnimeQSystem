using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AnimeQSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Writers");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Writers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3157c049-679e-41ba-9269-118d671346b1", 0, "5daf15e6-291b-46dd-9526-7d6259719492", "johndoe@example.com", true, false, null, "JOHNDOE@EXAMPLE.COM", "JOHNDOE", "AQAAAAIAAYagAAAAEHrJQDTRi1pkqrnAWT5JfOvW1ZVeedEci4G+OZe5+CK+QcXk3//Vkks65LFk8YFVIw==", null, false, "faa2833b-4170-4786-b563-ffd473c1a363", false, "johndoe" },
                    { "afea43d5-db77-40d6-bd23-3d3577c529ee", 0, "cfe24bbc-c574-4e3a-a435-2de8cbd7868f", "alexjohnson@example.com", true, false, null, "ALEXJOHNSON@EXAMPLE.COM", "ALEXJOHNSON", "AQAAAAIAAYagAAAAEHrJQDTRi1pkqrnAWT5JfOvW1ZVeedEci4G+OZe5+CK+QcXk3//Vkks65LFk8YFVIw==", null, false, "f3f20eef-2e85-4d5d-b682-fa6c0285efa7", false, "alexjohnson" },
                    { "d64e070a-7acd-4290-8f30-a1ad13d465b0", 0, "dc491f98-8dbd-43be-871a-621c0f48d18d", "janesmith@example.com", true, false, null, "JANESMITH@EXAMPLE.COM", "JANESMITH", "AQAAAAIAAYagAAAAEHrJQDTRi1pkqrnAWT5JfOvW1ZVeedEci4G+OZe5+CK+QcXk3//Vkks65LFk8YFVIw==", null, false, "a700e63c-9370-4189-88e5-9af8a836b34e", false, "janesmith" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("430f3069-a397-461a-9dce-5cd9fd7ea516"), "Everyday life experiences.", "Slice of Life" },
                    { new Guid("6bedbbed-a33c-4734-8f09-7dcbf0e1c5a1"), "Magical worlds and imaginative storytelling.", "Fantasy" },
                    { new Guid("da926f91-813c-429f-93ce-1a610fb18d2b"), "Emotionally intense and story-driven.", "Drama" },
                    { new Guid("e74499d6-6592-4c1c-a99e-0500c915c028"), "Exciting journeys and discoveries.", "Adventure" },
                    { new Guid("eb26586b-2c5c-4779-886a-6f6152e6d4e4"), "Love and relationships.", "Romance" }
                });

            migrationBuilder.InsertData(
                table: "Studios",
                columns: new[] { "Id", "DateFounded", "Name" },
                values: new object[,]
                {
                    { new Guid("42c9bc6c-6fbe-4fc0-9143-438047eee4e6"), new DateTime(1956, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toho Animation" },
                    { new Guid("6daec29e-4f30-44d0-920c-1f050636edf4"), new DateTime(2007, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "CoMix Wave Films" },
                    { new Guid("710fbaa2-690e-4331-9a34-8841dfe80dcf"), new DateTime(1972, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Madhouse" },
                    { new Guid("b722c905-7333-427c-9cb0-9665439a643f"), new DateTime(1985, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Studio Ghibli" },
                    { new Guid("fa923d27-c1d3-46cd-927a-e779953f81a7"), new DateTime(1981, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kyoto Animation" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Country", "CreatedAt", "FirstName", "Gender", "IdentityUserId", "IsDeleted", "LastModified", "LastName", "Points" },
                values: new object[,]
                {
                    { new Guid("8d8261e0-c672-41c8-b31e-940f838b9c19"), 22, "UK", new DateTime(2024, 11, 20, 21, 31, 43, 131, DateTimeKind.Local).AddTicks(4794), "Alex", 2, "afea43d5-db77-40d6-bd23-3d3577c529ee", false, new DateTime(2024, 11, 20, 21, 31, 43, 131, DateTimeKind.Local).AddTicks(4796), "Johnson", 800 },
                    { new Guid("bfd1a97f-8330-46c9-9905-bf885a3f76c9"), 30, "Canada", new DateTime(2024, 11, 20, 21, 31, 43, 131, DateTimeKind.Local).AddTicks(4775), "Jane", 1, "d64e070a-7acd-4290-8f30-a1ad13d465b0", false, new DateTime(2024, 11, 20, 21, 31, 43, 131, DateTimeKind.Local).AddTicks(4777), "Smith", 1500 },
                    { new Guid("f17ce454-1360-4689-8e5f-9814b0c7a0b1"), 25, "USA", new DateTime(2024, 11, 20, 21, 31, 43, 131, DateTimeKind.Local).AddTicks(4755), "John", 0, "3157c049-679e-41ba-9269-118d671346b1", false, new DateTime(2024, 11, 20, 21, 31, 43, 131, DateTimeKind.Local).AddTicks(4757), "Doe", 1200 }
                });

            migrationBuilder.InsertData(
                table: "Writers",
                columns: new[] { "Id", "DateOfBirth", "FavoriteGenreId", "FirstName", "Gender", "HairColor", "Height", "LastName" },
                values: new object[,]
                {
                    { new Guid("329233eb-e5b9-4b35-95de-29e9fdcbfbf8"), new DateTime(1941, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6bedbbed-a33c-4734-8f09-7dcbf0e1c5a1"), "Hayao", null, null, null, "Miyazaki" },
                    { new Guid("811e559a-bdb9-4d09-98be-9e39a54f34c6"), new DateTime(1981, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6bedbbed-a33c-4734-8f09-7dcbf0e1c5a1"), "Naoko", null, null, null, "Yamada" },
                    { new Guid("eee1e809-b16b-44a9-a816-34bd6d56b0ec"), new DateTime(1973, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("eb26586b-2c5c-4779-886a-6f6152e6d4e4"), "Makoto", null, null, null, "Shinkai" }
                });

            migrationBuilder.InsertData(
                table: "Animes",
                columns: new[] { "Id", "Episodes", "GenreId", "Rating", "ReleaseDate", "Seasons", "StillOngoing", "StudioId", "Title", "WriterId" },
                values: new object[,]
                {
                    { new Guid("202e5a57-d1f0-4eeb-ba3d-cadb12c2f046"), 1, new Guid("6bedbbed-a33c-4734-8f09-7dcbf0e1c5a1"), 5, new DateTime(2001, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, new Guid("b722c905-7333-427c-9cb0-9665439a643f"), "Spirited Away", new Guid("329233eb-e5b9-4b35-95de-29e9fdcbfbf8") },
                    { new Guid("d402c974-e9e4-46fb-b37e-2b98f5c11370"), 1, new Guid("da926f91-813c-429f-93ce-1a610fb18d2b"), 4, new DateTime(2016, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, new Guid("fa923d27-c1d3-46cd-927a-e779953f81a7"), "A Silent Voice", new Guid("811e559a-bdb9-4d09-98be-9e39a54f34c6") },
                    { new Guid("f603ec70-750b-4104-a644-d6ac5bbc81c5"), 1, new Guid("eb26586b-2c5c-4779-886a-6f6152e6d4e4"), 5, new DateTime(2016, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, new Guid("6daec29e-4f30-44d0-920c-1f050636edf4"), "Your Name", new Guid("eee1e809-b16b-44a9-a816-34bd6d56b0ec") }
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "CreatedAt", "CreatorId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("5e201ab6-f741-4a27-a323-d301d4beacf8"), new DateTime(2024, 11, 20, 21, 31, 43, 131, DateTimeKind.Local).AddTicks(6556), new Guid("8d8261e0-c672-41c8-b31e-940f838b9c19"), "Test your knowledge about A Silent Voice.", "A Silent Voice Quiz" },
                    { new Guid("6b398fe4-6ef4-442d-87f1-de79ceedc93e"), new DateTime(2024, 11, 20, 21, 31, 43, 131, DateTimeKind.Local).AddTicks(6561), new Guid("bfd1a97f-8330-46c9-9905-bf885a3f76c9"), "Test your knowledge about Your Name.", "Your Name Quiz" },
                    { new Guid("7d44ccc0-3135-4b04-91cc-ac7bed491e6d"), new DateTime(2024, 11, 20, 21, 31, 43, 131, DateTimeKind.Local).AddTicks(6524), new Guid("f17ce454-1360-4689-8e5f-9814b0c7a0b1"), "Test your knowledge about Spirited Away.", "Spirited Away Quiz" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Age", "AnimeId", "FirstName", "Gender", "HairColor", "Height", "IsMainCharacter", "LastName", "Skill", "Weakness", "Weapon" },
                values: new object[,]
                {
                    { new Guid("242fc014-ef5d-4ed9-83ff-c6e2be90b8b6"), null, new Guid("f603ec70-750b-4104-a644-d6ac5bbc81c5"), "Mitsuha", null, null, null, false, "Miyamizu", "Get back in time", null, null },
                    { new Guid("2af7c14c-fcad-437c-89ff-ee348d0eedcf"), null, new Guid("202e5a57-d1f0-4eeb-ba3d-cadb12c2f046"), "Haku", null, null, null, false, null, "Turn into Dragon", null, null },
                    { new Guid("4f777f86-0ad5-4563-b71f-b9bed5b9a38f"), null, new Guid("202e5a57-d1f0-4eeb-ba3d-cadb12c2f046"), "No-Face", null, null, null, false, null, "Making gold", null, null },
                    { new Guid("6dd62844-c8ad-43ca-a2a7-6e1df26bdffa"), null, new Guid("f603ec70-750b-4104-a644-d6ac5bbc81c5"), "Taki", null, null, null, false, "Tachibana", "Get back in time", null, null },
                    { new Guid("93fe7a4a-e5ca-44c3-a216-64e6c1770bd9"), null, new Guid("202e5a57-d1f0-4eeb-ba3d-cadb12c2f046"), "Chihiro", null, null, null, false, "Ogino", "Being happy", null, null },
                    { new Guid("b6f3ac48-d9c4-49e6-a5f9-b168ed84edd8"), null, new Guid("d402c974-e9e4-46fb-b37e-2b98f5c11370"), "Shoya", null, null, null, false, "Ishida", "Cute smile", null, null },
                    { new Guid("cfd97a38-cdd0-4a7b-bad8-2319145b8822"), null, new Guid("d402c974-e9e4-46fb-b37e-2b98f5c11370"), "Shoko", null, null, null, false, "Nishimiya", "Sign language", null, null }
                });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "Answer", "QuizId", "QuizType", "Title" },
                values: new object[,]
                {
                    { new Guid("04b48086-084f-4a1e-af06-2fb7d84a2bae"), null, new Guid("5e201ab6-f741-4a27-a323-d301d4beacf8"), 1, "What is the name of the main protagonist in A Silent Voice?" },
                    { new Guid("3248796b-1137-41bc-b3a8-9365073bbd52"), null, new Guid("6b398fe4-6ef4-442d-87f1-de79ceedc93e"), 1, "What is the name of the main character in Your Name?" },
                    { new Guid("428cdcfb-2d29-4e20-9160-d091ad892e6c"), "True", new Guid("6b398fe4-6ef4-442d-87f1-de79ceedc93e"), 0, "True or False: Taki and Mitsuha swap bodies in Your Name." },
                    { new Guid("50d6b8ef-2ee2-4930-906b-4be181d6ccec"), "True", new Guid("5e201ab6-f741-4a27-a323-d301d4beacf8"), 0, "True or False: Shoya Ishida is a former bully in A Silent Voice." },
                    { new Guid("5b637830-a893-43c5-8cd1-3416317050e7"), null, new Guid("7d44ccc0-3135-4b04-91cc-ac7bed491e6d"), 1, "Who runs the bathhouse in Spirited Away?" },
                    { new Guid("67cb3af6-fc59-4cd2-9795-14a0e9983c10"), null, new Guid("7d44ccc0-3135-4b04-91cc-ac7bed491e6d"), 1, "What is the name of the main protagonist in Spirited Away?" },
                    { new Guid("7a9c3e97-6b5d-41be-ac92-c6079962f6e9"), "Shoko Nishimiya", new Guid("5e201ab6-f741-4a27-a323-d301d4beacf8"), 2, "Who does Shoya Ishida try to make amends with?" },
                    { new Guid("e80e95e7-d4cd-4cdf-b75d-cdcb20ddb1ef"), "False", new Guid("7d44ccc0-3135-4b04-91cc-ac7bed491e6d"), 0, "True or False: No-Face is a spirit who tries to eat Chihiro." },
                    { new Guid("ea3bd8e0-96e6-410a-a13a-bffa23f4ba43"), "Her real name", new Guid("7d44ccc0-3135-4b04-91cc-ac7bed491e6d"), 2, "What does Chihiro need to remember to return home?" }
                });

            migrationBuilder.InsertData(
                table: "QuizOptions",
                columns: new[] { "Id", "IsCorrect", "OptionText", "QuizQuestionId" },
                values: new object[,]
                {
                    { new Guid("03571285-7761-4bb9-abbe-e0d2fdb2d290"), false, "Shoya Ishida", new Guid("3248796b-1137-41bc-b3a8-9365073bbd52") },
                    { new Guid("040c14ad-807d-4ce0-81aa-d247161e9ffb"), true, "Shoya Ishida", new Guid("04b48086-084f-4a1e-af06-2fb7d84a2bae") },
                    { new Guid("1a936afb-0f81-4eac-9894-da6e4a2f347e"), false, "Haku", new Guid("5b637830-a893-43c5-8cd1-3416317050e7") },
                    { new Guid("2b91d97f-9267-42d3-8cd2-ff5947683d89"), false, "Kamaji", new Guid("5b637830-a893-43c5-8cd1-3416317050e7") },
                    { new Guid("2ccf121c-ef2a-4fd7-b7ff-ce9be2df2355"), true, "Taki Tachibana", new Guid("3248796b-1137-41bc-b3a8-9365073bbd52") },
                    { new Guid("36d19cf4-281b-43ca-93af-45d6a9984005"), true, "Chihiro Ogino", new Guid("67cb3af6-fc59-4cd2-9795-14a0e9983c10") },
                    { new Guid("3ff05e53-8380-43e2-8a3f-8141cbea4186"), false, "Chihiro Ogino", new Guid("3248796b-1137-41bc-b3a8-9365073bbd52") },
                    { new Guid("43ccdfb9-7910-4494-8e6f-9c426d4a67b0"), false, "Satsuki Kusakabe", new Guid("67cb3af6-fc59-4cd2-9795-14a0e9983c10") },
                    { new Guid("690788bc-151f-4e13-9e7e-d88a139af425"), false, "Mitsuha Miyamizu", new Guid("04b48086-084f-4a1e-af06-2fb7d84a2bae") },
                    { new Guid("732f203f-0a41-4fe1-9850-cfe28d1855d3"), false, "Taki Tachibana", new Guid("04b48086-084f-4a1e-af06-2fb7d84a2bae") },
                    { new Guid("7d8e13dd-72dd-4014-80d3-a3f43c5236e5"), false, "Shoko Nishimiya", new Guid("04b48086-084f-4a1e-af06-2fb7d84a2bae") },
                    { new Guid("afd5b5fa-6e8f-4840-a1f7-d08b2ec43e3e"), false, "Nausicaä", new Guid("67cb3af6-fc59-4cd2-9795-14a0e9983c10") },
                    { new Guid("b3e80635-a50f-43f2-927b-9d0f418fd9a3"), true, "Yubaba", new Guid("5b637830-a893-43c5-8cd1-3416317050e7") },
                    { new Guid("bef8ab3a-a97c-4304-9b20-0001fc8c35b8"), false, "Zeniba", new Guid("5b637830-a893-43c5-8cd1-3416317050e7") },
                    { new Guid("d4975182-0427-488f-9fc4-2bd5b7eceda3"), true, "Mitsuha Miyamizu", new Guid("3248796b-1137-41bc-b3a8-9365073bbd52") },
                    { new Guid("e6d09574-5752-4646-a8e6-7d1235e8287a"), false, "Sophie Hatter", new Guid("67cb3af6-fc59-4cd2-9795-14a0e9983c10") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: new Guid("242fc014-ef5d-4ed9-83ff-c6e2be90b8b6"));

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: new Guid("2af7c14c-fcad-437c-89ff-ee348d0eedcf"));

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: new Guid("4f777f86-0ad5-4563-b71f-b9bed5b9a38f"));

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: new Guid("6dd62844-c8ad-43ca-a2a7-6e1df26bdffa"));

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: new Guid("93fe7a4a-e5ca-44c3-a216-64e6c1770bd9"));

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: new Guid("b6f3ac48-d9c4-49e6-a5f9-b168ed84edd8"));

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: new Guid("cfd97a38-cdd0-4a7b-bad8-2319145b8822"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("430f3069-a397-461a-9dce-5cd9fd7ea516"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("e74499d6-6592-4c1c-a99e-0500c915c028"));

            migrationBuilder.DeleteData(
                table: "QuizOptions",
                keyColumn: "Id",
                keyValue: new Guid("03571285-7761-4bb9-abbe-e0d2fdb2d290"));

            migrationBuilder.DeleteData(
                table: "QuizOptions",
                keyColumn: "Id",
                keyValue: new Guid("040c14ad-807d-4ce0-81aa-d247161e9ffb"));

            migrationBuilder.DeleteData(
                table: "QuizOptions",
                keyColumn: "Id",
                keyValue: new Guid("1a936afb-0f81-4eac-9894-da6e4a2f347e"));

            migrationBuilder.DeleteData(
                table: "QuizOptions",
                keyColumn: "Id",
                keyValue: new Guid("2b91d97f-9267-42d3-8cd2-ff5947683d89"));

            migrationBuilder.DeleteData(
                table: "QuizOptions",
                keyColumn: "Id",
                keyValue: new Guid("2ccf121c-ef2a-4fd7-b7ff-ce9be2df2355"));

            migrationBuilder.DeleteData(
                table: "QuizOptions",
                keyColumn: "Id",
                keyValue: new Guid("36d19cf4-281b-43ca-93af-45d6a9984005"));

            migrationBuilder.DeleteData(
                table: "QuizOptions",
                keyColumn: "Id",
                keyValue: new Guid("3ff05e53-8380-43e2-8a3f-8141cbea4186"));

            migrationBuilder.DeleteData(
                table: "QuizOptions",
                keyColumn: "Id",
                keyValue: new Guid("43ccdfb9-7910-4494-8e6f-9c426d4a67b0"));

            migrationBuilder.DeleteData(
                table: "QuizOptions",
                keyColumn: "Id",
                keyValue: new Guid("690788bc-151f-4e13-9e7e-d88a139af425"));

            migrationBuilder.DeleteData(
                table: "QuizOptions",
                keyColumn: "Id",
                keyValue: new Guid("732f203f-0a41-4fe1-9850-cfe28d1855d3"));

            migrationBuilder.DeleteData(
                table: "QuizOptions",
                keyColumn: "Id",
                keyValue: new Guid("7d8e13dd-72dd-4014-80d3-a3f43c5236e5"));

            migrationBuilder.DeleteData(
                table: "QuizOptions",
                keyColumn: "Id",
                keyValue: new Guid("afd5b5fa-6e8f-4840-a1f7-d08b2ec43e3e"));

            migrationBuilder.DeleteData(
                table: "QuizOptions",
                keyColumn: "Id",
                keyValue: new Guid("b3e80635-a50f-43f2-927b-9d0f418fd9a3"));

            migrationBuilder.DeleteData(
                table: "QuizOptions",
                keyColumn: "Id",
                keyValue: new Guid("bef8ab3a-a97c-4304-9b20-0001fc8c35b8"));

            migrationBuilder.DeleteData(
                table: "QuizOptions",
                keyColumn: "Id",
                keyValue: new Guid("d4975182-0427-488f-9fc4-2bd5b7eceda3"));

            migrationBuilder.DeleteData(
                table: "QuizOptions",
                keyColumn: "Id",
                keyValue: new Guid("e6d09574-5752-4646-a8e6-7d1235e8287a"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("428cdcfb-2d29-4e20-9160-d091ad892e6c"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("50d6b8ef-2ee2-4930-906b-4be181d6ccec"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("7a9c3e97-6b5d-41be-ac92-c6079962f6e9"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("e80e95e7-d4cd-4cdf-b75d-cdcb20ddb1ef"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("ea3bd8e0-96e6-410a-a13a-bffa23f4ba43"));

            migrationBuilder.DeleteData(
                table: "Studios",
                keyColumn: "Id",
                keyValue: new Guid("42c9bc6c-6fbe-4fc0-9143-438047eee4e6"));

            migrationBuilder.DeleteData(
                table: "Studios",
                keyColumn: "Id",
                keyValue: new Guid("710fbaa2-690e-4331-9a34-8841dfe80dcf"));

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: new Guid("202e5a57-d1f0-4eeb-ba3d-cadb12c2f046"));

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: new Guid("d402c974-e9e4-46fb-b37e-2b98f5c11370"));

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: new Guid("f603ec70-750b-4104-a644-d6ac5bbc81c5"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("04b48086-084f-4a1e-af06-2fb7d84a2bae"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("3248796b-1137-41bc-b3a8-9365073bbd52"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("5b637830-a893-43c5-8cd1-3416317050e7"));

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: new Guid("67cb3af6-fc59-4cd2-9795-14a0e9983c10"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("da926f91-813c-429f-93ce-1a610fb18d2b"));

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: new Guid("5e201ab6-f741-4a27-a323-d301d4beacf8"));

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: new Guid("6b398fe4-6ef4-442d-87f1-de79ceedc93e"));

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: new Guid("7d44ccc0-3135-4b04-91cc-ac7bed491e6d"));

            migrationBuilder.DeleteData(
                table: "Studios",
                keyColumn: "Id",
                keyValue: new Guid("6daec29e-4f30-44d0-920c-1f050636edf4"));

            migrationBuilder.DeleteData(
                table: "Studios",
                keyColumn: "Id",
                keyValue: new Guid("b722c905-7333-427c-9cb0-9665439a643f"));

            migrationBuilder.DeleteData(
                table: "Studios",
                keyColumn: "Id",
                keyValue: new Guid("fa923d27-c1d3-46cd-927a-e779953f81a7"));

            migrationBuilder.DeleteData(
                table: "Writers",
                keyColumn: "Id",
                keyValue: new Guid("329233eb-e5b9-4b35-95de-29e9fdcbfbf8"));

            migrationBuilder.DeleteData(
                table: "Writers",
                keyColumn: "Id",
                keyValue: new Guid("811e559a-bdb9-4d09-98be-9e39a54f34c6"));

            migrationBuilder.DeleteData(
                table: "Writers",
                keyColumn: "Id",
                keyValue: new Guid("eee1e809-b16b-44a9-a816-34bd6d56b0ec"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("6bedbbed-a33c-4734-8f09-7dcbf0e1c5a1"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("eb26586b-2c5c-4779-886a-6f6152e6d4e4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8d8261e0-c672-41c8-b31e-940f838b9c19"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bfd1a97f-8330-46c9-9905-bf885a3f76c9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f17ce454-1360-4689-8e5f-9814b0c7a0b1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3157c049-679e-41ba-9269-118d671346b1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "afea43d5-db77-40d6-bd23-3d3577c529ee");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d64e070a-7acd-4290-8f30-a1ad13d465b0");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Writers");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Writers",
                type: "int",
                maxLength: 100000,
                nullable: true);
        }
    }
}
