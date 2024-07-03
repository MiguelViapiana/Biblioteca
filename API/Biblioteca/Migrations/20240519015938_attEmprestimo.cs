using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NomeDoProjeto.Migrations
{
    /// <inheritdoc />
    public partial class attEmprestimo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TabelaEmprestimos_TabelaLivros_LivroId",
                table: "TabelaEmprestimos");

            migrationBuilder.DropForeignKey(
                name: "FK_TabelaEmprestimos_TabelaUsuarios_UsuarioId",
                table: "TabelaEmprestimos");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TabelaEmprestimos_TabelaLivros_LivroId",
                table: "TabelaEmprestimos");

            migrationBuilder.DropForeignKey(
                name: "FK_TabelaEmprestimos_TabelaUsuarios_UsuarioId",
                table: "TabelaEmprestimos");

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
    }
}
