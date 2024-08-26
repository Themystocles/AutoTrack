using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTrack.Migrations
{
    /// <inheritdoc />
    public partial class exclusãovaltotetc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Peca_Servico",
                table: "servicos");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "servicos");

            migrationBuilder.DropColumn(
                name: "ValorTot",
                table: "servicos");

            migrationBuilder.DropColumn(
                name: "ValorUni",
                table: "servicos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Peca_Servico",
                table: "servicos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "servicos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ValorTot",
                table: "servicos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ValorUni",
                table: "servicos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
