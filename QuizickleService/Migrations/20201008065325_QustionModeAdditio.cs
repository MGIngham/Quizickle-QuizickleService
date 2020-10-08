using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizickleService.Migrations
{
    public partial class QustionModeAdditio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizId = table.Column<int>(nullable: false),
                    QuestionNumber = table.Column<int>(nullable: false),
                    QuestionType = table.Column<int>(nullable: false),
                    QuestionText = table.Column<string>(nullable: false),
                    IsTrueFalse = table.Column<bool>(nullable: false),
                    AnswerText = table.Column<string>(nullable: true),
                    OptionOne = table.Column<string>(nullable: true),
                    OptionTwo = table.Column<string>(nullable: true),
                    OptionThree = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuizId",
                table: "Question",
                column: "QuizId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Question");
        }
    }
}
