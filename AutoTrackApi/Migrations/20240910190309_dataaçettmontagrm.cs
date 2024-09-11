using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTrack.Migrations
{
    /// <inheritdoc />
    public partial class dataaçettmontagrm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dataalerta",
                table: "montagens",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dataalerta",
                table: "montagens");
        }
    }
}
