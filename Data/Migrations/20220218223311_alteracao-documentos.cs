using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class alteracaodocumentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identificador",
                table: "Documentos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identificador",
                table: "Documentos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
