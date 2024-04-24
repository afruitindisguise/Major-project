using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Major_project.Migrations
{
    /// <inheritdoc />
    public partial class newer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataPlayer");

            migrationBuilder.AddColumn<int>(
                name: "DataId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Players_DataId",
                table: "Players",
                column: "DataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Datas_DataId",
                table: "Players",
                column: "DataId",
                principalTable: "Datas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Datas_DataId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_DataId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "DataId",
                table: "Players");

            migrationBuilder.CreateTable(
                name: "DataPlayer",
                columns: table => new
                {
                    DatasId = table.Column<int>(type: "int", nullable: false),
                    PlayersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPlayer", x => new { x.DatasId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_DataPlayer_Datas_DatasId",
                        column: x => x.DatasId,
                        principalTable: "Datas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataPlayer_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataPlayer_PlayersId",
                table: "DataPlayer",
                column: "PlayersId");
        }
    }
}
