using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmreWebApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boklån",
                columns: table => new
                {
                    Boklån_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Utlånad = table.Column<bool>(nullable: false),
                    LåneDatum = table.Column<DateTime>(nullable: true),
                    ReturDatum = table.Column<DateTime>(nullable: true),
                    BokId = table.Column<int>(nullable: false),
                    LåntagareId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boklån", x => x.Boklån_Id);
                });

            migrationBuilder.CreateTable(
                name: "Böcker",
                columns: table => new
                {
                    Bok_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isbn = table.Column<int>(nullable: false),
                    BokTitel = table.Column<string>(nullable: false),
                    Författare = table.Column<string>(nullable: true),
                    Betyg = table.Column<int>(nullable: false),
                    UtgivningsÅr = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Böcker", x => x.Bok_Id);
                });

            migrationBuilder.CreateTable(
                name: "Låntagare",
                columns: table => new
                {
                    Lånekort = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(maxLength: 50, nullable: false),
                    Efternamn = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Låntagare", x => x.Lånekort);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boklån");

            migrationBuilder.DropTable(
                name: "Böcker");

            migrationBuilder.DropTable(
                name: "Låntagare");
        }
    }
}
