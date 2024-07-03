using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NomeDoProjeto.Migrations
{
    /// <inheritdoc />
    public partial class AddEmprestimo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    AvaliacaoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Estrelas = table.Column<int>(type: "INTEGER", nullable: false),
                    Usuario = table.Column<string>(type: "TEXT", nullable: false),
                    LivroId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.AvaliacaoId);
                    table.ForeignKey(
                        name: "FK_Avaliacao_TabelaLivros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "TabelaLivros",
                        principalColumn: "LivroId");
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    ComentarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Texto = table.Column<string>(type: "TEXT", nullable: false),
                    Usuario = table.Column<string>(type: "TEXT", nullable: false),
                    LivroId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.ComentarioId);
                    table.ForeignKey(
                        name: "FK_Comentario_TabelaLivros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "TabelaLivros",
                        principalColumn: "LivroId");
                });

            migrationBuilder.CreateTable(
                name: "TabelaEmprestimos",
                columns: table => new
                {
                    EmprestimoId = table.Column<string>(type: "TEXT", nullable: false),
                    UsuarioId = table.Column<string>(type: "TEXT", nullable: false),
                    LivroId = table.Column<string>(type: "TEXT", nullable: false),
                    DataEmprestimo = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaEmprestimos", x => x.EmprestimoId);
                    table.ForeignKey(
                        name: "FK_TabelaEmprestimos_TabelaLivros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "TabelaLivros",
                        principalColumn: "LivroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TabelaEmprestimos_TabelaUsuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TabelaUsuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_LivroId",
                table: "Avaliacao",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_LivroId",
                table: "Comentario",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_TabelaEmprestimos_LivroId",
                table: "TabelaEmprestimos",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_TabelaEmprestimos_UsuarioId",
                table: "TabelaEmprestimos",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "TabelaEmprestimos");
        }
    }
}
