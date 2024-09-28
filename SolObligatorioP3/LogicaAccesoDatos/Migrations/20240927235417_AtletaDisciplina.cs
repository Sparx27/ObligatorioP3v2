using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AtletaDisciplina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Atletas_AtletaId",
                table: "Disciplinas");

            migrationBuilder.DropIndex(
                name: "IX_Disciplinas_AtletaId",
                table: "Disciplinas");

            migrationBuilder.DropColumn(
                name: "AtletaId",
                table: "Disciplinas");

            migrationBuilder.CreateTable(
                name: "AtletaDisciplina",
                columns: table => new
                {
                    LiAtletasId = table.Column<int>(type: "int", nullable: false),
                    LiDisciplinasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtletaDisciplina", x => new { x.LiAtletasId, x.LiDisciplinasId });
                    table.ForeignKey(
                        name: "FK_AtletaDisciplina_Atletas_LiAtletasId",
                        column: x => x.LiAtletasId,
                        principalTable: "Atletas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtletaDisciplina_Disciplinas_LiDisciplinasId",
                        column: x => x.LiDisciplinasId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtletaDisciplina_LiDisciplinasId",
                table: "AtletaDisciplina",
                column: "LiDisciplinasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtletaDisciplina");

            migrationBuilder.AddColumn<int>(
                name: "AtletaId",
                table: "Disciplinas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_AtletaId",
                table: "Disciplinas",
                column: "AtletaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Atletas_AtletaId",
                table: "Disciplinas",
                column: "AtletaId",
                principalTable: "Atletas",
                principalColumn: "Id");
        }
    }
}
