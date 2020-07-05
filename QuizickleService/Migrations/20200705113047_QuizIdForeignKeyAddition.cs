using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizickleService.Migrations
{
    public partial class QuizIdForeignKeyAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuizId1",
                table: "Quiz",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quiz_QuizId1",
                table: "Quiz",
                column: "QuizId1");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quiz_QuizId",
                table: "Questions",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Quiz_QuizId1",
                table: "Quiz",
                column: "QuizId1",
                principalTable: "Quiz",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quiz_QuizId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Quiz_QuizId1",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_QuizId1",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuizId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuizId1",
                table: "Quiz");
        }
    }
}
