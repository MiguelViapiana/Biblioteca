using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NomeDoProjeto.Migrations
{
    /// <inheritdoc />
    public partial class Permissao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TabelaDevolucao_TabelaEmprestimos_EmprestimoId",
                table: "TabelaDevolucao");

            migrationBuilder.DropIndex(
                name: "IX_TabelaDevolucao_EmprestimoId",
                table: "TabelaDevolucao");

            migrationBuilder.AddColumn<int>(
                name: "Permissao",
                table: "TabelaUsuarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Permissao",
                table: "TabelaUsuarios");

            migrationBuilder.CreateIndex(
                name: "IX_TabelaDevolucao_EmprestimoId",
                table: "TabelaDevolucao",
                column: "EmprestimoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TabelaDevolucao_TabelaEmprestimos_EmprestimoId",
                table: "TabelaDevolucao",
                column: "EmprestimoId",
                principalTable: "TabelaEmprestimos",
                principalColumn: "EmprestimoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
