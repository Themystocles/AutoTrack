using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTrack.Migrations
{
    /// <inheritdoc />
    public partial class retirandokmatual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KmAtual",
                table: "Veiculos");

            migrationBuilder.AddColumn<string>(
                name: "KmAtual",
                table: "orcamentos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KmAtual",
                table: "orcamentos");

            migrationBuilder.AddColumn<string>(
                name: "KmAtual",
                table: "Veiculos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
