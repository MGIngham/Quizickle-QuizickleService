using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizickleService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizId = table.Column<int>(nullable: false),
                    RoundNumber = table.Column<int>(nullable: false),
                    QuestionString = table.Column<string>(nullable: false),
                    QuestionTypeId = table.Column<int>(nullable: false),
                    CorrectAnswerIndex = table.Column<int>(nullable: false),
                    AnswerString = table.Column<string>(nullable: true),
                    OptionOne = table.Column<string>(nullable: true),
                    OptionTwo = table.Column<string>(nullable: true),
                    OptionThree = table.Column<string>(nullable: true),
                    OptionFour = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
