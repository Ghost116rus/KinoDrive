using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinoDrive.Persistance.Migrations
{
    public partial class updateDBAddLangtitude : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AgeRestriction",
                table: "Films",
                type: "decimal(2,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<float>(
                name: "Latitude",
                table: "BranchOffices",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Longitude",
                table: "BranchOffices",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeRestriction",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "BranchOffices");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "BranchOffices");
        }
    }
}
