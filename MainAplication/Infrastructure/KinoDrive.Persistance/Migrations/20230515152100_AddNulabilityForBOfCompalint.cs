using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinoDrive.Persistance.Migrations
{
    public partial class AddNulabilityForBOfCompalint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_BranchOffices_BranchOfficeId",
                table: "Complaints");

            migrationBuilder.AlterColumn<int>(
                name: "BranchOfficeId",
                table: "Complaints",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_BranchOffices_BranchOfficeId",
                table: "Complaints",
                column: "BranchOfficeId",
                principalTable: "BranchOffices",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_BranchOffices_BranchOfficeId",
                table: "Complaints");

            migrationBuilder.AlterColumn<int>(
                name: "BranchOfficeId",
                table: "Complaints",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_BranchOffices_BranchOfficeId",
                table: "Complaints",
                column: "BranchOfficeId",
                principalTable: "BranchOffices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
