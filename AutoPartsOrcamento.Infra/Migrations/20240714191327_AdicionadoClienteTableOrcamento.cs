using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPartsOrcamento.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoClienteTableOrcamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VeiculoId",
                table: "Orcamentos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentos_VeiculoId",
                table: "Orcamentos",
                column: "VeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamentos_Veiculos_VeiculoId",
                table: "Orcamentos",
                column: "VeiculoId",
                principalTable: "Veiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcamentos_Veiculos_VeiculoId",
                table: "Orcamentos");

            migrationBuilder.DropIndex(
                name: "IX_Orcamentos_VeiculoId",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "VeiculoId",
                table: "Orcamentos");
        }
    }
}
