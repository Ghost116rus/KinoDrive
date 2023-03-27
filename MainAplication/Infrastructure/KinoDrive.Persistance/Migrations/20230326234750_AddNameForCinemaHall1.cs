using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinoDrive.Persistance.Migrations
{
    public partial class AddNameForCinemaHall1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CinemaHalls_OfficeId",
                table: "CinemaHalls");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaHalls_OfficeId_Name",
                table: "CinemaHalls",
                columns: new[] { "OfficeId", "Name" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CinemaHalls_OfficeId_Name",
                table: "CinemaHalls");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaHalls_OfficeId",
                table: "CinemaHalls",
                column: "OfficeId");
        }
    }
}
