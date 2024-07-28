using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPartsOrcamento.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddTipoCodigoSimilarTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CodigoSimilarProdutos_CotacaoItems_CotacaoItemId",
                table: "CodigoSimilarProdutos");

            migrationBuilder.AlterColumn<Guid>(
                name: "CotacaoItemId",
                table: "CodigoSimilarProdutos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "CodigoSimilarProdutos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CodigoSimilarProdutos_CotacaoItems_CotacaoItemId",
                table: "CodigoSimilarProdutos",
                column: "CotacaoItemId",
                principalTable: "CotacaoItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CodigoSimilarProdutos_CotacaoItems_CotacaoItemId",
                table: "CodigoSimilarProdutos");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "CodigoSimilarProdutos");

            migrationBuilder.AlterColumn<Guid>(
                name: "CotacaoItemId",
                table: "CodigoSimilarProdutos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_CodigoSimilarProdutos_CotacaoItems_CotacaoItemId",
                table: "CodigoSimilarProdutos",
                column: "CotacaoItemId",
                principalTable: "CotacaoItems",
                principalColumn: "Id");
        }
    }
}
