using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTrack.Migrations
{
    /// <inheritdoc />
    public partial class MudandoConfiguracaoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orcamentos_estoques_EstoqueId",
                table: "orcamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_orcamentos_montagens_MontagemId",
                table: "orcamentos");

            migrationBuilder.AlterColumn<int>(
                name: "MontagemId",
                table: "orcamentos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "EstoqueId",
                table: "orcamentos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_orcamentos_estoques_EstoqueId",
                table: "orcamentos",
                column: "EstoqueId",
                principalTable: "estoques",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orcamentos_montagens_MontagemId",
                table: "orcamentos",
                column: "MontagemId",
                principalTable: "montagens",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orcamentos_estoques_EstoqueId",
                table: "orcamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_orcamentos_montagens_MontagemId",
                table: "orcamentos");

            migrationBuilder.AlterColumn<int>(
                name: "MontagemId",
                table: "orcamentos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstoqueId",
                table: "orcamentos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_orcamentos_estoques_EstoqueId",
                table: "orcamentos",
                column: "EstoqueId",
                principalTable: "estoques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orcamentos_montagens_MontagemId",
                table: "orcamentos",
                column: "MontagemId",
                principalTable: "montagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
