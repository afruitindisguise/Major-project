using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Major_project.Migrations
{
    /// <inheritdoc />
    public partial class Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "Datas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HP = table.Column<int>(type: "int", nullable: false),
                    MP = table.Column<int>(type: "int", nullable: false),
                    AR = table.Column<int>(type: "int", nullable: false),
                    cordsx = table.Column<int>(type: "int", nullable: false),
                    cordsy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dmgPturn = table.Column<int>(type: "int", nullable: false),
                    applied = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "ItemPlayer",
                columns: table => new
                {
                    itemsId = table.Column<int>(type: "int", nullable: false),
                    playersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPlayer", x => new { x.itemsId, x.playersId });
                    table.ForeignKey(
                        name: "FK_ItemPlayer_Items_itemsId",
                        column: x => x.itemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPlayer_Players_playersId",
                        column: x => x.playersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStatus",
                columns: table => new
                {
                    StatusesId = table.Column<int>(type: "int", nullable: false),
                    playersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStatus", x => new { x.StatusesId, x.playersId });
                    table.ForeignKey(
                        name: "FK_PlayerStatus_Players_playersId",
                        column: x => x.playersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerStatus_Status_StatusesId",
                        column: x => x.StatusesId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Datas",
                columns: new[] { "Id", "AR", "HP", "MP", "cordsx", "cordsy" },
                values: new object[] { 1, 0, 100, 100, 0, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_DataPlayer_PlayersId",
                table: "DataPlayer",
                column: "PlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPlayer_playersId",
                table: "ItemPlayer",
                column: "playersId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatus_playersId",
                table: "PlayerStatus",
                column: "playersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataPlayer");

            migrationBuilder.DropTable(
                name: "ItemPlayer");

            migrationBuilder.DropTable(
                name: "PlayerStatus");

            migrationBuilder.DropTable(
                name: "Datas");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "UserName" },
                values: new object[] { 1, "a_fruit_in_disguise" });
        }
    }
}
