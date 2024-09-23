using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTrack.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoRelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionariosOrcamento");

            migrationBuilder.CreateTable(
                name: "OrcamentoFuncionarios",
                columns: table => new
                {
                    OrcamentoId = table.Column<int>(type: "INTEGER", nullable: false),
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentoFuncionarios", x => new { x.OrcamentoId, x.FuncionarioId });
                    table.ForeignKey(
                        name: "FK_OrcamentoFuncionarios_funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "funcionarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrcamentoFuncionarios_orcamentos_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "orcamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoFuncionarios_FuncionarioId",
                table: "OrcamentoFuncionarios",
                column: "FuncionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrcamentoFuncionarios");

            migrationBuilder.CreateTable(
                name: "FuncionariosOrcamento",
                columns: table => new
                {
                    funcionariosid = table.Column<int>(type: "INTEGER", nullable: false),
                    orcamentosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionariosOrcamento", x => new { x.funcionariosid, x.orcamentosId });
                    table.ForeignKey(
                        name: "FK_FuncionariosOrcamento_funcionarios_funcionariosid",
                        column: x => x.funcionariosid,
                        principalTable: "funcionarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionariosOrcamento_orcamentos_orcamentosId",
                        column: x => x.orcamentosId,
                        principalTable: "orcamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuncionariosOrcamento_orcamentosId",
                table: "FuncionariosOrcamento",
                column: "orcamentosId");
        }
    }
}
