using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class campovalorentregador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorEntregador",
                table: "Entregas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorEntregador",
                table: "Entregas");
        }
    }
}
