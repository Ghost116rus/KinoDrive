using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinoDrive.Persistance.Migrations
{
    public partial class AddDbSetForPreviousMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFilmRating_Films_FilmId",
                table: "UserFilmRating");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFilmRating_Users_UserId",
                table: "UserFilmRating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFilmRating",
                table: "UserFilmRating");

            migrationBuilder.RenameTable(
                name: "UserFilmRating",
                newName: "UserFilmRatings");

            migrationBuilder.RenameIndex(
                name: "IX_UserFilmRating_FilmId",
                table: "UserFilmRatings",
                newName: "IX_UserFilmRatings_FilmId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFilmRatings",
                table: "UserFilmRatings",
                columns: new[] { "UserId", "FilmId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFilmRatings_Films_FilmId",
                table: "UserFilmRatings",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFilmRatings_Users_UserId",
                table: "UserFilmRatings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFilmRatings_Films_FilmId",
                table: "UserFilmRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFilmRatings_Users_UserId",
                table: "UserFilmRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFilmRatings",
                table: "UserFilmRatings");

            migrationBuilder.RenameTable(
                name: "UserFilmRatings",
                newName: "UserFilmRating");

            migrationBuilder.RenameIndex(
                name: "IX_UserFilmRatings_FilmId",
                table: "UserFilmRating",
                newName: "IX_UserFilmRating_FilmId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFilmRating",
                table: "UserFilmRating",
                columns: new[] { "UserId", "FilmId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFilmRating_Films_FilmId",
                table: "UserFilmRating",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFilmRating_Users_UserId",
                table: "UserFilmRating",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
