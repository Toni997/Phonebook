using Microsoft.EntityFrameworkCore.Migrations;

namespace MojiKontaktiAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kontakti",
                columns: table => new
                {
                    KontaktID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nadimak = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bookmarkiran = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontakti", x => x.KontaktID);
                });

            migrationBuilder.CreateTable(
                name: "BrojeviTelefona",
                columns: table => new
                {
                    BrojTelefonaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KontaktID = table.Column<int>(type: "int", nullable: false),
                    PozivniBrojDrzave = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Broj = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Glavni = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrojeviTelefona", x => x.BrojTelefonaID);
                    table.ForeignKey(
                        name: "FK_BrojeviTelefona_Kontakti_KontaktID",
                        column: x => x.KontaktID,
                        principalTable: "Kontakti",
                        principalColumn: "KontaktID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailAdrese",
                columns: table => new
                {
                    EmailAdresaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KontaktID = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Glavna = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAdrese", x => x.EmailAdresaID);
                    table.ForeignKey(
                        name: "FK_EmailAdrese_Kontakti_KontaktID",
                        column: x => x.KontaktID,
                        principalTable: "Kontakti",
                        principalColumn: "KontaktID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tagovi",
                columns: table => new
                {
                    TagID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KontaktID = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tagovi", x => x.TagID);
                    table.ForeignKey(
                        name: "FK_Tagovi_Kontakti_KontaktID",
                        column: x => x.KontaktID,
                        principalTable: "Kontakti",
                        principalColumn: "KontaktID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrojeviTelefona_KontaktID",
                table: "BrojeviTelefona",
                column: "KontaktID");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAdrese_KontaktID",
                table: "EmailAdrese",
                column: "KontaktID");

            migrationBuilder.CreateIndex(
                name: "IX_Tagovi_KontaktID",
                table: "Tagovi",
                column: "KontaktID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrojeviTelefona");

            migrationBuilder.DropTable(
                name: "EmailAdrese");

            migrationBuilder.DropTable(
                name: "Tagovi");

            migrationBuilder.DropTable(
                name: "Kontakti");
        }
    }
}
