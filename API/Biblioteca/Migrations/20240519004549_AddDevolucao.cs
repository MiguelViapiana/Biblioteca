using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NomeDoProjeto.Migrations
{
    /// <inheritdoc />
    public partial class AddDevolucao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacao_TabelaLivros_LivroId",
                table: "Avaliacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_TabelaLivros_LivroId",
                table: "Comentario");

            migrationBuilder.DropForeignKey(
                name: "FK_TabelaEmprestimos_TabelaLivros_LivroId",
                table: "TabelaEmprestimos");

            migrationBuilder.DropForeignKey(
                name: "FK_TabelaEmprestimos_TabelaUsuarios_UsuarioId",
                table: "TabelaEmprestimos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Avaliacao",
                table: "Avaliacao");

            migrationBuilder.RenameTable(
                name: "Comentario",
                newName: "TabelaComentario");

            migrationBuilder.RenameTable(
                name: "Avaliacao",
                newName: "TabelaAvalicao");

            migrationBuilder.RenameIndex(
                name: "IX_Comentario_LivroId",
                table: "TabelaComentario",
                newName: "IX_TabelaComentario_LivroId");

            migrationBuilder.RenameIndex(
                name: "IX_Avaliacao_LivroId",
                table: "TabelaAvalicao",
                newName: "IX_TabelaAvalicao_LivroId");

            migrationBuilder.AddColumn<bool>(
                name: "Emprestado",
                table: "TabelaLivros",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "TabelaEmprestimos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "LivroId",
                table: "TabelaEmprestimos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEmprestimo",
                table: "TabelaEmprestimos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TabelaComentario",
                table: "TabelaComentario",
                column: "ComentarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TabelaAvalicao",
                table: "TabelaAvalicao",
                column: "AvaliacaoId");

            migrationBuilder.CreateTable(
                name: "TabelaDevolucao",
                columns: table => new
                {
                    DevolucaoId = table.Column<string>(type: "TEXT", nullable: false),
                    EmprestimoId = table.Column<string>(type: "TEXT", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaDevolucao", x => x.DevolucaoId);
                    table.ForeignKey(
                        name: "FK_TabelaDevolucao_TabelaEmprestimos_EmprestimoId",
                        column: x => x.EmprestimoId,
                        principalTable: "TabelaEmprestimos",
                        principalColumn: "EmprestimoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TabelaDevolucao_EmprestimoId",
                table: "TabelaDevolucao",
                column: "EmprestimoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TabelaAvalicao_TabelaLivros_LivroId",
                table: "TabelaAvalicao",
                column: "LivroId",
                principalTable: "TabelaLivros",
                principalColumn: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_TabelaComentario_TabelaLivros_LivroId",
                table: "TabelaComentario",
                column: "LivroId",
                principalTable: "TabelaLivros",
                principalColumn: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_TabelaEmprestimos_TabelaLivros_LivroId",
                table: "TabelaEmprestimos",
                column: "LivroId",
                principalTable: "TabelaLivros",
                principalColumn: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_TabelaEmprestimos_TabelaUsuarios_UsuarioId",
                table: "TabelaEmprestimos",
                column: "UsuarioId",
                principalTable: "TabelaUsuarios",
                principalColumn: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TabelaAvalicao_TabelaLivros_LivroId",
                table: "TabelaAvalicao");

            migrationBuilder.DropForeignKey(
                name: "FK_TabelaComentario_TabelaLivros_LivroId",
                table: "TabelaComentario");

            migrationBuilder.DropForeignKey(
                name: "FK_TabelaEmprestimos_TabelaLivros_LivroId",
                table: "TabelaEmprestimos");

            migrationBuilder.DropForeignKey(
                name: "FK_TabelaEmprestimos_TabelaUsuarios_UsuarioId",
                table: "TabelaEmprestimos");

            migrationBuilder.DropTable(
                name: "TabelaDevolucao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TabelaComentario",
                table: "TabelaComentario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TabelaAvalicao",
                table: "TabelaAvalicao");

            migrationBuilder.DropColumn(
                name: "Emprestado",
                table: "TabelaLivros");

            migrationBuilder.RenameTable(
                name: "TabelaComentario",
                newName: "Comentario");

            migrationBuilder.RenameTable(
                name: "TabelaAvalicao",
                newName: "Avaliacao");

            migrationBuilder.RenameIndex(
                name: "IX_TabelaComentario_LivroId",
                table: "Comentario",
                newName: "IX_Comentario_LivroId");

            migrationBuilder.RenameIndex(
                name: "IX_TabelaAvalicao_LivroId",
                table: "Avaliacao",
                newName: "IX_Avaliacao_LivroId");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "TabelaEmprestimos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LivroId",
                table: "TabelaEmprestimos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEmprestimo",
                table: "TabelaEmprestimos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario",
                column: "ComentarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Avaliacao",
                table: "Avaliacao",
                column: "AvaliacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_TabelaLivros_LivroId",
                table: "Avaliacao",
                column: "LivroId",
                principalTable: "TabelaLivros",
                principalColumn: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_TabelaLivros_LivroId",
                table: "Comentario",
                column: "LivroId",
                principalTable: "TabelaLivros",
                principalColumn: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_TabelaEmprestimos_TabelaLivros_LivroId",
                table: "TabelaEmprestimos",
                column: "LivroId",
                principalTable: "TabelaLivros",
                principalColumn: "LivroId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TabelaEmprestimos_TabelaUsuarios_UsuarioId",
                table: "TabelaEmprestimos",
                column: "UsuarioId",
                principalTable: "TabelaUsuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
