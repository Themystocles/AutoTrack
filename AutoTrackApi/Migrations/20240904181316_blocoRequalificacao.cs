using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTrack.Migrations
{
    /// <inheritdoc />
    public partial class blocoRequalificacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Laudo",
                table: "servicos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MarcaCilindro",
                table: "servicos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MarcaValvula",
                table: "servicos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotaDaValvula",
                table: "servicos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotaDeServico",
                table: "servicos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroCilindro",
                table: "servicos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroValvula",
                table: "servicos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ordem",
                table: "servicos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Requalificadora",
                table: "servicos",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Laudo",
                table: "servicos");

            migrationBuilder.DropColumn(
                name: "MarcaCilindro",
                table: "servicos");

            migrationBuilder.DropColumn(
                name: "MarcaValvula",
                table: "servicos");

            migrationBuilder.DropColumn(
                name: "NotaDaValvula",
                table: "servicos");

            migrationBuilder.DropColumn(
                name: "NotaDeServico",
                table: "servicos");

            migrationBuilder.DropColumn(
                name: "NumeroCilindro",
                table: "servicos");

            migrationBuilder.DropColumn(
                name: "NumeroValvula",
                table: "servicos");

            migrationBuilder.DropColumn(
                name: "Ordem",
                table: "servicos");

            migrationBuilder.DropColumn(
                name: "Requalificadora",
                table: "servicos");
        }
    }
}
