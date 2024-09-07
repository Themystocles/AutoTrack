using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTrack.Migrations
{
    /// <inheritdoc />
    public partial class correcoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentacaoAno",
                table: "montagens");

            migrationBuilder.DropColumn(
                name: "Orcamento",
                table: "montagens");

            migrationBuilder.DropColumn(
                name: "QuantPecaServico",
                table: "montagens");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroCilindro",
                table: "montagens",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumeroCilindro",
                table: "montagens",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "DocumentacaoAno",
                table: "montagens",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Orcamento",
                table: "montagens",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "QuantPecaServico",
                table: "montagens",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
