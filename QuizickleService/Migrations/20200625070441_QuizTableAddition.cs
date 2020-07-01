using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizickleService.Migrations
{
    public partial class QuizTableAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    QuizId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.QuizId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quiz");
        }
    }
}
