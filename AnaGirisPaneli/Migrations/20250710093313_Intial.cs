using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnaGirisPaneli.Migrations
{
    /// <inheritdoc />
    public partial class Intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "Kullanicilar",
                newName: "Mail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KMail",
                table: "Kullanicilar",
                newName: "Mail");
        }
    }
}
