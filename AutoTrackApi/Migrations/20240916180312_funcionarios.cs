using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTrack.Migrations
{
    /// <inheritdoc />
    public partial class funcionarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Funcionariosid",
                table: "orcamentos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: true),
                    DataAdmissao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DataDemissao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Situacao = table.Column<string>(type: "TEXT", nullable: true),
                    DataFerias = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Funcao = table.Column<string>(type: "TEXT", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Celular1 = table.Column<string>(type: "TEXT", nullable: true),
                    Celular2 = table.Column<string>(type: "TEXT", nullable: true),
                    Rua = table.Column<string>(type: "TEXT", nullable: true),
                    Cep = table.Column<string>(type: "TEXT", nullable: true),
                    Cidade = table.Column<string>(type: "TEXT", nullable: true),
                    Bairro = table.Column<string>(type: "TEXT", nullable: true),
                    Foto = table.Column<byte[]>(type: "BLOB", nullable: true),
                    OrcamentosId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionarios", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orcamentos_Funcionariosid",
                table: "orcamentos",
                column: "Funcionariosid");

            migrationBuilder.AddForeignKey(
                name: "FK_orcamentos_funcionarios_Funcionariosid",
                table: "orcamentos",
                column: "Funcionariosid",
                principalTable: "funcionarios",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orcamentos_funcionarios_Funcionariosid",
                table: "orcamentos");

            migrationBuilder.DropTable(
                name: "funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_orcamentos_Funcionariosid",
                table: "orcamentos");

            migrationBuilder.DropColumn(
                name: "Funcionariosid",
                table: "orcamentos");
        }
    }
}
