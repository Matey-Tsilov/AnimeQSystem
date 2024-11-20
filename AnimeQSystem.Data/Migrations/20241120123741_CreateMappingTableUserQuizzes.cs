using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeQSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateMappingTableUserQuizzes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Quizzes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_CreatorId",
                table: "Quizzes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizzesUsers_QuizId",
                table: "QuizzesUsers",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Users_CreatorId",
                table: "Quizzes",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Users_CreatorId",
                table: "Quizzes");

            migrationBuilder.DropTable(
                name: "QuizzesUsers");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_CreatorId",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Quizzes");
        }
    }
}
