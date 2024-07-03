using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NomeDoProjeto.Migrations
{
    /// <inheritdoc />
    public partial class attComentario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TabelaComentario_TabelaLivros_LivroId",
                table: "TabelaComentario");

            migrationBuilder.AlterColumn<string>(
                name: "LivroId",
                table: "TabelaComentario",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TabelaComentario_TabelaLivros_LivroId",
                table: "TabelaComentario",
                column: "LivroId",
                principalTable: "TabelaLivros",
                principalColumn: "LivroId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TabelaComentario_TabelaLivros_LivroId",
                table: "TabelaComentario");

            migrationBuilder.AlterColumn<string>(
                name: "LivroId",
                table: "TabelaComentario",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_TabelaComentario_TabelaLivros_LivroId",
                table: "TabelaComentario",
                column: "LivroId",
                principalTable: "TabelaLivros",
                principalColumn: "LivroId");
        }
    }
}
