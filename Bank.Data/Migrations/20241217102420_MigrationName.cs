using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.Data.Migrations
{
    public partial class MigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bankers",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    phonNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "turns",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bankerid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_turns", x => x.id);
                    table.ForeignKey(
                        name: "FK_turns_bankers_bankerid",
                        column: x => x.bankerid,
                        principalTable: "bankers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    phonNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    TurnId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                    table.ForeignKey(
                        name: "FK_customers_turns_TurnId",
                        column: x => x.TurnId,
                        principalTable: "turns",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customers_TurnId",
                table: "customers",
                column: "TurnId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_turns_bankerid",
                table: "turns",
                column: "bankerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "turns");

            migrationBuilder.DropTable(
                name: "bankers");
        }
    }
}
