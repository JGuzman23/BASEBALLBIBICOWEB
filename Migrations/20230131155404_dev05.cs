using Microsoft.EntityFrameworkCore.Migrations;

namespace BASEBALLBIBICOWEB.Migrations
{
    public partial class dev05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prespuesta_Preguntas_IdPreguntasId",
                table: "Prespuesta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prespuesta",
                table: "Prespuesta");

            migrationBuilder.RenameTable(
                name: "Prespuesta",
                newName: "Respuesta");

            migrationBuilder.RenameIndex(
                name: "IX_Prespuesta_IdPreguntasId",
                table: "Respuesta",
                newName: "IX_Respuesta_IdPreguntasId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Respuesta",
                table: "Respuesta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Respuesta_Preguntas_IdPreguntasId",
                table: "Respuesta",
                column: "IdPreguntasId",
                principalTable: "Preguntas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Respuesta_Preguntas_IdPreguntasId",
                table: "Respuesta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Respuesta",
                table: "Respuesta");

            migrationBuilder.RenameTable(
                name: "Respuesta",
                newName: "Prespuesta");

            migrationBuilder.RenameIndex(
                name: "IX_Respuesta_IdPreguntasId",
                table: "Prespuesta",
                newName: "IX_Prespuesta_IdPreguntasId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prespuesta",
                table: "Prespuesta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prespuesta_Preguntas_IdPreguntasId",
                table: "Prespuesta",
                column: "IdPreguntasId",
                principalTable: "Preguntas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
