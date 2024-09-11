using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTrack.Migrations
{
    /// <inheritdoc />
    public partial class removergatantiaveiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Garantia",
                table: "Veiculos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Garantia",
                table: "Veiculos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
