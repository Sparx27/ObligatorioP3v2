using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Valor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AnioIntegracion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Habitantes = table.Column<int>(type: "int", nullable: false),
                    NombreDelegado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelDelegado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email_Valor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RolUsuario = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdAdminRegistro = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Contrasena_Valor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePrueba = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    FchInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FchFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atletas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    PaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atletas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atletas_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "PuntajeEventoAtleta",
                columns: table => new
                {
                    AtletaId = table.Column<int>(type: "int", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false),
                    Puntaje = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntajeEventoAtleta", x => new { x.AtletaId, x.EventoId });
                    table.ForeignKey(
                        name: "FK_PuntajeEventoAtleta_Atletas_AtletaId",
                        column: x => x.AtletaId,
                        principalTable: "Atletas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PuntajeEventoAtleta_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtletaDisciplina_LiDisciplinasId",
                table: "AtletaDisciplina",
                column: "LiDisciplinasId");

            migrationBuilder.CreateIndex(
                name: "IX_Atletas_PaisId",
                table: "Atletas",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_Nombre_Valor",
                table: "Disciplinas",
                column: "Nombre_Valor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_DisciplinaId",
                table: "Eventos",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_PuntajeEventoAtleta_EventoId",
                table: "PuntajeEventoAtleta",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email_Valor",
                table: "Usuarios",
                column: "Email_Valor",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtletaDisciplina");

            migrationBuilder.DropTable(
                name: "PuntajeEventoAtleta");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Atletas");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Disciplinas");
        }
    }
}
