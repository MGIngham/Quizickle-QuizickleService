using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizickleService.Migrations
{
    public partial class QuestionModelEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionNumber",
                table: "Questions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionNumber",
                table: "Questions");
        }
    }
}
