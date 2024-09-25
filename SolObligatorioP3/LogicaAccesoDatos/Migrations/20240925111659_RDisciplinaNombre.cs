using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class RDisciplinaNombre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Disciplinas",
                newName: "Nombre_Valor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre_Valor",
                table: "Disciplinas",
                newName: "Nombre");
        }
    }
}
