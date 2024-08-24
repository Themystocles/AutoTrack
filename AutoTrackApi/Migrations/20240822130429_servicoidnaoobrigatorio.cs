using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTrack.Migrations
{
    /// <inheritdoc />
    public partial class servicoidnaoobrigatorio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orcamentos_servicos_ServicoId",
                table: "orcamentos");

            migrationBuilder.AlterColumn<int>(
                name: "ServicoId",
                table: "orcamentos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_orcamentos_servicos_ServicoId",
                table: "orcamentos",
                column: "ServicoId",
                principalTable: "servicos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orcamentos_servicos_ServicoId",
                table: "orcamentos");

            migrationBuilder.AlterColumn<int>(
                name: "ServicoId",
                table: "orcamentos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_orcamentos_servicos_ServicoId",
                table: "orcamentos",
                column: "ServicoId",
                principalTable: "servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
