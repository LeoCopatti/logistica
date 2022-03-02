using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Correcaocampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UltimaAtualização",
                table: "Clientes",
                newName: "UltimaAtualizacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UltimaAtualizacao",
                table: "Clientes",
                newName: "UltimaAtualização");
        }
    }
}
