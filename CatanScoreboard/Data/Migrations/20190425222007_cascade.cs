using Microsoft.EntityFrameworkCore.Migrations;

namespace CatanScoreboard.Data.Migrations
{
    public partial class cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerScores_FinishedGames_FinishedGameId",
                table: "PlayerScores");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerScores_FinishedGames_FinishedGameId",
                table: "PlayerScores",
                column: "FinishedGameId",
                principalTable: "FinishedGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerScores_FinishedGames_FinishedGameId",
                table: "PlayerScores");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerScores_FinishedGames_FinishedGameId",
                table: "PlayerScores",
                column: "FinishedGameId",
                principalTable: "FinishedGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
