using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeQSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexPropertyToQuizQuestionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "QuizQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Index",
                table: "QuizQuestions");
        }
    }
}
