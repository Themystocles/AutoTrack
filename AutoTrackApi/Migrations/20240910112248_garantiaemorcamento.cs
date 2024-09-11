using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTrack.Migrations
{
    /// <inheritdoc />
    public partial class garantiaemorcamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Garantia",
                table: "orcamentos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Garantia",
                table: "orcamentos");
        }
    }
}
