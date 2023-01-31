using Microsoft.EntityFrameworkCore.Migrations;

namespace BASEBALLBIBICOWEB.Migrations
{
    public partial class dev04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Vista",
                table: "Preguntas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vista",
                table: "Preguntas");
        }
    }
}
