using Microsoft.EntityFrameworkCore.Migrations;

namespace MojiKontaktiAPI.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kontakti",
                columns: new[] { "KontaktID", "Adresa", "Bookmarkiran", "Ime", "Nadimak", "Prezime" },
                values: new object[,]
                {
                    { 15, null, false, "Ante", null, "Gotovac" },
                    { 16, null, false, "Josip", null, "Gabrilović" },
                    { 17, null, true, "Mirna", "Maca", "Medić" },
                    { 18, null, false, "Bruno", null, "Medaković" },
                    { 19, null, true, "Toni", "Kazi", "Kazinoti" }
                });

            migrationBuilder.InsertData(
                table: "BrojeviTelefona",
                columns: new[] { "BrojTelefonaID", "Broj", "Glavni", "KontaktID", "Opis", "PozivniBrojDrzave" },
                values: new object[,]
                {
                    { 15, "923587894", false, 15, "Posao", "385" },
                    { 16, "958796574", false, 16, "Bolnica", "385" },
                    { 17, "915647893", false, 17, "Privatni", "385" },
                    { 18, "986542389", false, 18, "Posao", "385" },
                    { 19, "923587894", false, 19, "Privatni", "385" },
                    { 20, "953652178", false, 19, "Posao", "385" }
                });

            migrationBuilder.InsertData(
                table: "EmailAdrese",
                columns: new[] { "EmailAdresaID", "Email", "Glavna", "KontaktID" },
                values: new object[,]
                {
                    { 15, "ante.g@hotmail.com", false, 15 },
                    { 16, "mirnaaaa@gmail.com", false, 17 },
                    { 17, "toni.kazinoti@gmail.com", false, 19 },
                    { 18, "tk48322@unist.hr", false, 19 }
                });

            migrationBuilder.InsertData(
                table: "Tagovi",
                columns: new[] { "TagID", "KontaktID", "Naziv" },
                values: new object[,]
                {
                    { 15, 15, "Prijatelj" },
                    { 16, 15, "Zvati u 8h" },
                    { 17, 17, "Rođak" },
                    { 18, 19, "Brat" },
                    { 19, 19, "Najjači" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BrojeviTelefona",
                keyColumn: "BrojTelefonaID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "BrojeviTelefona",
                keyColumn: "BrojTelefonaID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "BrojeviTelefona",
                keyColumn: "BrojTelefonaID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "BrojeviTelefona",
                keyColumn: "BrojTelefonaID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "BrojeviTelefona",
                keyColumn: "BrojTelefonaID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "BrojeviTelefona",
                keyColumn: "BrojTelefonaID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "EmailAdrese",
                keyColumn: "EmailAdresaID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "EmailAdrese",
                keyColumn: "EmailAdresaID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "EmailAdrese",
                keyColumn: "EmailAdresaID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "EmailAdrese",
                keyColumn: "EmailAdresaID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tagovi",
                keyColumn: "TagID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tagovi",
                keyColumn: "TagID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tagovi",
                keyColumn: "TagID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tagovi",
                keyColumn: "TagID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tagovi",
                keyColumn: "TagID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Kontakti",
                keyColumn: "KontaktID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Kontakti",
                keyColumn: "KontaktID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Kontakti",
                keyColumn: "KontaktID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Kontakti",
                keyColumn: "KontaktID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Kontakti",
                keyColumn: "KontaktID",
                keyValue: 19);
        }
    }
}
