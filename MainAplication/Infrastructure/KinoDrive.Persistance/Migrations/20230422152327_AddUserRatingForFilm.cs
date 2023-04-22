using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinoDrive.Persistance.Migrations
{
    public partial class AddUserRatingForFilm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "RatingOnImdb",
                table: "Films",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "UserFilmRating",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(2,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFilmRating", x => new { x.UserId, x.FilmId });
                    table.ForeignKey(
                        name: "FK_UserFilmRating_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFilmRating_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFilmRating_FilmId",
                table: "UserFilmRating",
                column: "FilmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFilmRating");

            migrationBuilder.AlterColumn<int>(
                name: "RatingOnImdb",
                table: "Films",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
