using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinoDrive.Persistance.Migrations
{
    public partial class AddAnswerForComplaintAndRemoveBornCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BornCountry",
                table: "FilmDirectors");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Complaints",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Complaints");

            migrationBuilder.AddColumn<string>(
                name: "BornCountry",
                table: "FilmDirectors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
