using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinoDrive.Persistance.Migrations
{
    public partial class AddTicketCost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketCost",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketCost",
                table: "Bookings");
        }
    }
}
