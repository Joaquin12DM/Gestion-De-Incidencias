using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionIncidencia.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migracion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlumnoId",
                table: "Incidencia",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incidencia_AlumnoId",
                table: "Incidencia",
                column: "AlumnoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidencia_Alumno_AlumnoId",
                table: "Incidencia",
                column: "AlumnoId",
                principalTable: "Alumno",
                principalColumn: "IdAlumno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidencia_Alumno_AlumnoId",
                table: "Incidencia");

            migrationBuilder.DropIndex(
                name: "IX_Incidencia_AlumnoId",
                table: "Incidencia");

            migrationBuilder.DropColumn(
                name: "AlumnoId",
                table: "Incidencia");
        }
    }
}
