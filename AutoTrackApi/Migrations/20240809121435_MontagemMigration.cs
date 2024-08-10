using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTrack.Migrations
{
    /// <inheritdoc />
    public partial class MontagemMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Renavam",
                table: "Veiculos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Montagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    data = table.Column<string>(type: "TEXT", nullable: false),
                    GeracaoInstaladores = table.Column<string>(type: "TEXT", nullable: false),
                    RedutorValor = table.Column<decimal>(type: "TEXT", nullable: false),
                    NumeroSerie = table.Column<string>(type: "TEXT", nullable: false),
                    FormaPagamento = table.Column<string>(type: "TEXT", nullable: false),
                    MarcaCilindro = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroCilindro = table.Column<int>(type: "INTEGER", nullable: false),
                    Quilo = table.Column<decimal>(type: "TEXT", nullable: false),
                    Litro = table.Column<decimal>(type: "TEXT", nullable: false),
                    AnoFab = table.Column<int>(type: "INTEGER", nullable: false),
                    DocumentacaoAno = table.Column<int>(type: "INTEGER", nullable: false),
                    AnoReteste = table.Column<int>(type: "INTEGER", nullable: false),
                    Requalificadora = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroNFEquipamento = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroOrdemRequalificacao = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroLaudoMontagem = table.Column<string>(type: "TEXT", nullable: false),
                    MarcaValvula = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroNFServicoMontagem = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroValvula = table.Column<string>(type: "TEXT", nullable: false),
                    Selo = table.Column<string>(type: "TEXT", nullable: false),
                    Orcamento = table.Column<decimal>(type: "TEXT", nullable: false),
                    QuantPecaServico = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    KitDaLoja = table.Column<bool>(type: "INTEGER", nullable: false),
                    VeiculoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Montagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Montagem_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Montagem_VeiculoId",
                table: "Montagem",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Montagem");

            migrationBuilder.DropColumn(
                name: "Renavam",
                table: "Veiculos");
        }
    }
}
