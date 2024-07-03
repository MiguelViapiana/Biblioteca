using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NomeDoProjeto.Migrations
{
    /// <inheritdoc />
    public partial class DevolucaoUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LivroId",
                table: "TabelaDevolucao",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "TabelaDevolucao",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LivroId",
                table: "TabelaDevolucao");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TabelaDevolucao");
        }
    }
}
