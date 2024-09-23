using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTrack.Migrations
{
    /// <inheritdoc />
    public partial class retirandofkfuncionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orcamentos_funcionarios_Funcionariosid",
                table: "orcamentos");

            migrationBuilder.DropIndex(
                name: "IX_orcamentos_Funcionariosid",
                table: "orcamentos");

            migrationBuilder.DropColumn(
                name: "Funcionariosid",
                table: "orcamentos");

            migrationBuilder.DropColumn(
                name: "OrcamentosId",
                table: "funcionarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Funcionariosid",
                table: "orcamentos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrcamentosId",
                table: "funcionarios",
                type: "INTEGER",
                nullable: true);

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
    }
}
