using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinoDrive.Persistance.Migrations
{
    public partial class AddManagers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchOfficeId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_BranchOfficeId",
                table: "Users",
                column: "BranchOfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_BranchOffices_BranchOfficeId",
                table: "Users",
                column: "BranchOfficeId",
                principalTable: "BranchOffices",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_BranchOffices_BranchOfficeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BranchOfficeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BranchOfficeId",
                table: "Users");
        }
    }
}
