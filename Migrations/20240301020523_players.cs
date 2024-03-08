using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Major_project.Migrations
{
    /// <inheritdoc />
    public partial class players : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerScore_Scores_ScoresScoreId",
                table: "PlayerScore");

            migrationBuilder.RenameColumn(
                name: "ScoreId",
                table: "Scores",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ScoresScoreId",
                table: "PlayerScore",
                newName: "ScoresId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerScore_ScoresScoreId",
                table: "PlayerScore",
                newName: "IX_PlayerScore_ScoresId");

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "UserName" },
                values: new object[] { 1, "a_fruit_in_disguise" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerScore_Scores_ScoresId",
                table: "PlayerScore",
                column: "ScoresId",
                principalTable: "Scores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerScore_Scores_ScoresId",
                table: "PlayerScore");

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Scores",
                newName: "ScoreId");

            migrationBuilder.RenameColumn(
                name: "ScoresId",
                table: "PlayerScore",
                newName: "ScoresScoreId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerScore_ScoresId",
                table: "PlayerScore",
                newName: "IX_PlayerScore_ScoresScoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerScore_Scores_ScoresScoreId",
                table: "PlayerScore",
                column: "ScoresScoreId",
                principalTable: "Scores",
                principalColumn: "ScoreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
