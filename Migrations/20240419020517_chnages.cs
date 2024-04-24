using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Major_project.Migrations
{
    /// <inheritdoc />
    public partial class chnages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerStatus");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DeleteData(
                table: "Datas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "cordsx",
                table: "Datas");

            migrationBuilder.RenameColumn(
                name: "cordsy",
                table: "Datas",
                newName: "location");

            migrationBuilder.AlterColumn<double>(
                name: "AR",
                table: "Datas",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "location",
                table: "Datas",
                newName: "cordsy");

            migrationBuilder.AlterColumn<int>(
                name: "AR",
                table: "Datas",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "cordsx",
                table: "Datas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    applied = table.Column<bool>(type: "bit", nullable: false),
                    dmgPturn = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
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
                name: "IX_PlayerStatus_playersId",
                table: "PlayerStatus",
                column: "playersId");
        }
    }
}
