using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTrack.Migrations
{
    /// <inheritdoc />
    public partial class deleteproxmanuetrocdefiltro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProxManutencao",
                table: "Veiculos");

            migrationBuilder.DropColumn(
                name: "ProxTrocaFiltro",
                table: "Veiculos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProxManutencao",
                table: "Veiculos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProxTrocaFiltro",
                table: "Veiculos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
