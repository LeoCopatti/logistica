using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class inicioprojetooficial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Clientes_ClienteId",
                table: "Telefones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Telefones",
                table: "Telefones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Telefones",
                newName: "DDD");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Enderecos",
                newName: "EntregadorId");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroTelefone",
                table: "Telefones",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Telefones",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Telefones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EntregadorId",
                table: "Telefones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaAtualizacao",
                table: "Telefones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Enderecos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaAtualizacao",
                table: "Enderecos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Telefones",
                table: "Telefones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EmpresasContratantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorBaseEntrega = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresasContratantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entregadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelefonesExemplo",
                columns: table => new
                {
                    NumeroTelefone = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonesExemplo", x => new { x.ClienteId, x.NumeroTelefone });
                    table.ForeignKey(
                        name: "FK_TelefonesExemplo_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagemDocumento = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EntregadorId = table.Column<int>(type: "int", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentos_Entregadores_EntregadorId",
                        column: x => x.EntregadorId,
                        principalTable: "Entregadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Entregas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EntregadorId = table.Column<int>(type: "int", nullable: true),
                    EmpresaContratanteId = table.Column<int>(type: "int", nullable: true),
                    ValorEntrega = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entregas_EmpresasContratantes_EmpresaContratanteId",
                        column: x => x.EmpresaContratanteId,
                        principalTable: "EmpresasContratantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entregas_Entregadores_EntregadorId",
                        column: x => x.EntregadorId,
                        principalTable: "Entregadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ValoresEntregadorEmpresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntregadorId = table.Column<int>(type: "int", nullable: true),
                    EmpresaContratanteId = table.Column<int>(type: "int", nullable: true),
                    ValorEntrega = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValoresEntregadorEmpresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValoresEntregadorEmpresa_EmpresasContratantes_EmpresaContratanteId",
                        column: x => x.EmpresaContratanteId,
                        principalTable: "EmpresasContratantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ValoresEntregadorEmpresa_Entregadores_EntregadorId",
                        column: x => x.EntregadorId,
                        principalTable: "Entregadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_EntregadorId",
                table: "Telefones",
                column: "EntregadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_EntregadorId",
                table: "Enderecos",
                column: "EntregadorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_EntregadorId",
                table: "Documentos",
                column: "EntregadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_EmpresaContratanteId",
                table: "Entregas",
                column: "EmpresaContratanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_EntregadorId",
                table: "Entregas",
                column: "EntregadorId");

            migrationBuilder.CreateIndex(
                name: "IX_ValoresEntregadorEmpresa_EmpresaContratanteId",
                table: "ValoresEntregadorEmpresa",
                column: "EmpresaContratanteId");

            migrationBuilder.CreateIndex(
                name: "IX_ValoresEntregadorEmpresa_EntregadorId",
                table: "ValoresEntregadorEmpresa",
                column: "EntregadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Entregadores_EntregadorId",
                table: "Enderecos",
                column: "EntregadorId",
                principalTable: "Entregadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Entregadores_EntregadorId",
                table: "Telefones",
                column: "EntregadorId",
                principalTable: "Entregadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Entregadores_EntregadorId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Entregadores_EntregadorId",
                table: "Telefones");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "Entregas");

            migrationBuilder.DropTable(
                name: "TelefonesExemplo");

            migrationBuilder.DropTable(
                name: "ValoresEntregadorEmpresa");

            migrationBuilder.DropTable(
                name: "EmpresasContratantes");

            migrationBuilder.DropTable(
                name: "Entregadores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Telefones",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Telefones_EntregadorId",
                table: "Telefones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_EntregadorId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "EntregadorId",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "UltimaAtualizacao",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "UltimaAtualizacao",
                table: "Enderecos");

            migrationBuilder.RenameColumn(
                name: "DDD",
                table: "Telefones",
                newName: "ClienteId");

            migrationBuilder.RenameColumn(
                name: "EntregadorId",
                table: "Enderecos",
                newName: "ClienteId");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroTelefone",
                table: "Telefones",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Telefones",
                table: "Telefones",
                columns: new[] { "ClienteId", "NumeroTelefone" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Clientes_ClienteId",
                table: "Telefones",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
