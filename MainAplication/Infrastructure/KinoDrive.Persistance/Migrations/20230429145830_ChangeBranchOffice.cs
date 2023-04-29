using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinoDrive.Persistance.Migrations
{
    public partial class ChangeBranchOffice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkTime",
                table: "BranchOffices");

            migrationBuilder.AddColumn<int>(
                name: "EndWorkTime",
                table: "BranchOffices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartWorkTime",
                table: "BranchOffices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndWorkTime",
                table: "BranchOffices");

            migrationBuilder.DropColumn(
                name: "StartWorkTime",
                table: "BranchOffices");

            migrationBuilder.AddColumn<string>(
                name: "WorkTime",
                table: "BranchOffices",
                type: "char(11)",
                nullable: false,
                defaultValue: "");
        }
    }
}
