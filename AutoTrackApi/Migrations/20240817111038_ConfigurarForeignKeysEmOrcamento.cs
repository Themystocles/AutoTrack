using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTrack.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurarForeignKeysEmOrcamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_orcamentos_EstoqueId",
                table: "orcamentos",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_orcamentos_MontagemId",
                table: "orcamentos",
                column: "MontagemId");

            migrationBuilder.CreateIndex(
                name: "IX_orcamentos_ServicoId",
                table: "orcamentos",
                column: "ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_orcamentos_estoques_EstoqueId",
                table: "orcamentos",
                column: "EstoqueId",
                principalTable: "estoques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orcamentos_montagens_MontagemId",
                table: "orcamentos",
                column: "MontagemId",
                principalTable: "montagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orcamentos_servicos_ServicoId",
                table: "orcamentos",
                column: "ServicoId",
                principalTable: "servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orcamentos_estoques_EstoqueId",
                table: "orcamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_orcamentos_montagens_MontagemId",
                table: "orcamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_orcamentos_servicos_ServicoId",
                table: "orcamentos");

            migrationBuilder.DropIndex(
                name: "IX_orcamentos_EstoqueId",
                table: "orcamentos");

            migrationBuilder.DropIndex(
                name: "IX_orcamentos_MontagemId",
                table: "orcamentos");

            migrationBuilder.DropIndex(
                name: "IX_orcamentos_ServicoId",
                table: "orcamentos");
        }
    }
}
