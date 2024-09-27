using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ClaseAsociacion5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AtletaId",
                table: "Disciplinas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PuntajeEvenetoAtleta",
                columns: table => new
                {
                    AtletaId = table.Column<int>(type: "int", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false),
                    Puntaje = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntajeEvenetoAtleta", x => new { x.AtletaId, x.EventoId });
                    table.ForeignKey(
                        name: "FK_PuntajeEvenetoAtleta_Atletas_AtletaId",
                        column: x => x.AtletaId,
                        principalTable: "Atletas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PuntajeEvenetoAtleta_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_AtletaId",
                table: "Disciplinas",
                column: "AtletaId");

            migrationBuilder.CreateIndex(
                name: "IX_PuntajeEvenetoAtleta_EventoId",
                table: "PuntajeEvenetoAtleta",
                column: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Atletas_AtletaId",
                table: "Disciplinas",
                column: "AtletaId",
                principalTable: "Atletas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Atletas_AtletaId",
                table: "Disciplinas");

            migrationBuilder.DropTable(
                name: "PuntajeEvenetoAtleta");

            migrationBuilder.DropIndex(
                name: "IX_Disciplinas_AtletaId",
                table: "Disciplinas");

            migrationBuilder.DropColumn(
                name: "AtletaId",
                table: "Disciplinas");
        }
    }
}
