using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackIt.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioTelefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioSenha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalRaca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalTipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalCor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalSexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalObservacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalFoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalDtDesaparecimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnimalDtEncontro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnimalStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalsId);
                    table.ForeignKey(
                        name: "FK_Animals_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "Observacoes",
                columns: table => new
                {
                    ObservacoesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObservacoesDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObservacoesLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObservacoesData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnimalsId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observacoes", x => x.ObservacoesId);
                    table.ForeignKey(
                        name: "FK_Observacoes_Animals_AnimalsId",
                        column: x => x.AnimalsId,
                        principalTable: "Animals",
                        principalColumn: "AnimalsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Observacoes_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_UsuarioId",
                table: "Animals",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Observacoes_AnimalsId",
                table: "Observacoes",
                column: "AnimalsId");

            migrationBuilder.CreateIndex(
                name: "IX_Observacoes_UsuarioId",
                table: "Observacoes",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Observacoes");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
