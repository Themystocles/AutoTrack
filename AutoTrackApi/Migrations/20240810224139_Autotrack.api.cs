using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTrack.Migrations
{
    /// <inheritdoc />
    public partial class Autotrackapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    InsEstadual = table.Column<string>(type: "TEXT", nullable: false),
                    InsMunicipal = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    InsTelefone2 = table.Column<string>(type: "TEXT", nullable: false),
                    Endereco = table.Column<string>(type: "TEXT", nullable: false),
                    Bairro = table.Column<string>(type: "TEXT", nullable: false),
                    Cidade = table.Column<string>(type: "TEXT", nullable: false),
                    Cep = table.Column<string>(type: "TEXT", nullable: false),
                    Uf = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Carro = table.Column<string>(type: "TEXT", nullable: false),
                    Placa = table.Column<string>(type: "TEXT", nullable: false),
                    Especie = table.Column<string>(type: "TEXT", nullable: false),
                    Combustivel = table.Column<string>(type: "TEXT", nullable: false),
                    Potencia = table.Column<string>(type: "TEXT", nullable: false),
                    AnoFab = table.Column<string>(type: "TEXT", nullable: false),
                    Capacidade = table.Column<string>(type: "TEXT", nullable: false),
                    AnoModelo = table.Column<string>(type: "TEXT", nullable: false),
                    Chassi = table.Column<string>(type: "TEXT", nullable: false),
                    Cor = table.Column<string>(type: "TEXT", nullable: false),
                    Observacao = table.Column<string>(type: "TEXT", nullable: false),
                    KmAtual = table.Column<string>(type: "TEXT", nullable: false),
                    ProxManutencao = table.Column<string>(type: "TEXT", nullable: false),
                    ProxTrocaFiltro = table.Column<string>(type: "TEXT", nullable: false),
                    Garantia = table.Column<string>(type: "TEXT", nullable: false),
                    Renavam = table.Column<string>(type: "TEXT", nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "montagens",
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
                    table.PrimaryKey("PK_montagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_montagens_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "servicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    Peca_Servico = table.Column<string>(type: "TEXT", nullable: false),
                    ValorUni = table.Column<string>(type: "TEXT", nullable: false),
                    ValorTot = table.Column<string>(type: "TEXT", nullable: false),
                    FormaPag = table.Column<string>(type: "TEXT", nullable: false),
                    Mecanico = table.Column<string>(type: "TEXT", nullable: false),
                    Saida = table.Column<string>(type: "TEXT", nullable: false),
                    DataServico = table.Column<string>(type: "TEXT", nullable: false),
                    VeiculoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_servicos_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_montagens_VeiculoId",
                table: "montagens",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_servicos_VeiculoId",
                table: "servicos",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_ClienteId",
                table: "Veiculos",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "montagens");

            migrationBuilder.DropTable(
                name: "servicos");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
