using Microsoft.EntityFrameworkCore.Migrations;

namespace BASEBALLBIBICOWEB.Migrations
{
    public partial class dev03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Base",
                table: "Preguntas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Base",
                table: "Preguntas");
        }
    }
}
