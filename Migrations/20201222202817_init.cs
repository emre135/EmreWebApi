using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmreWebApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Böcker",
                columns: table => new
                {
                    Bok_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isbn = table.Column<int>(nullable: false),
                    BokTitel = table.Column<string>(nullable: false),
                    Betyg = table.Column<int>(nullable: false),
                    UtgivningsÅr = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Böcker", x => x.Bok_Id);
                });

            migrationBuilder.CreateTable(
                name: "Författares",
                columns: table => new
                {
                    FörfattareId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Författarenamn = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Författares", x => x.FörfattareId);
                });

            migrationBuilder.CreateTable(
                name: "Låntagares",
                columns: table => new
                {
                    LånekortId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(maxLength: 50, nullable: false),
                    Efternamn = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Låntagares", x => x.LånekortId);
                });

            migrationBuilder.CreateTable(
                name: "Saldo",
                columns: table => new
                {
                    SaldoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BokId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saldo", x => x.SaldoId);
                    table.ForeignKey(
                        name: "FK_Saldo_Böcker_BokId",
                        column: x => x.BokId,
                        principalTable: "Böcker",
                        principalColumn: "Bok_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BokFörfattare",
                columns: table => new
                {
                    BokId = table.Column<int>(nullable: false),
                    FörfattareId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BokFörfattare", x => new { x.BokId, x.FörfattareId });
                    table.ForeignKey(
                        name: "FK_BokFörfattare_Författares_BokId",
                        column: x => x.BokId,
                        principalTable: "Författares",
                        principalColumn: "FörfattareId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BokFörfattare_Böcker_FörfattareId",
                        column: x => x.FörfattareId,
                        principalTable: "Böcker",
                        principalColumn: "Bok_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Boklåns",
                columns: table => new
                {
                    BoklånId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Utlånad = table.Column<bool>(nullable: false),
                    LåneDatum = table.Column<DateTime>(nullable: true),
                    ReturDatum = table.Column<DateTime>(nullable: true),
                    LånekortId = table.Column<int>(nullable: false),
                    SaldoId = table.Column<int>(nullable: false),
                    LåntagareLånekortId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boklåns", x => x.BoklånId);
                    table.ForeignKey(
                        name: "FK_Boklåns_Låntagares_LåntagareLånekortId",
                        column: x => x.LåntagareLånekortId,
                        principalTable: "Låntagares",
                        principalColumn: "LånekortId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Boklåns_Saldo_SaldoId",
                        column: x => x.SaldoId,
                        principalTable: "Saldo",
                        principalColumn: "SaldoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BokFörfattare_FörfattareId",
                table: "BokFörfattare",
                column: "FörfattareId");

            migrationBuilder.CreateIndex(
                name: "IX_Boklåns_LåntagareLånekortId",
                table: "Boklåns",
                column: "LåntagareLånekortId");

            migrationBuilder.CreateIndex(
                name: "IX_Boklåns_SaldoId",
                table: "Boklåns",
                column: "SaldoId");

            migrationBuilder.CreateIndex(
                name: "IX_Saldo_BokId",
                table: "Saldo",
                column: "BokId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BokFörfattare");

            migrationBuilder.DropTable(
                name: "Boklåns");

            migrationBuilder.DropTable(
                name: "Författares");

            migrationBuilder.DropTable(
                name: "Låntagares");

            migrationBuilder.DropTable(
                name: "Saldo");

            migrationBuilder.DropTable(
                name: "Böcker");
        }
    }
}
