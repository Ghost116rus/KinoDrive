using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinoDrive.Persistance.Migrations
{
    public partial class addAdditionalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlForFile = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmImages_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmImages_FilmId",
                table: "FilmImages",
                column: "FilmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmImages");
        }
    }
}
