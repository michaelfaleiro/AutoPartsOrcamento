using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPartsOrcamento.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddTableStatusOrcamentoAndCotacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Cotacao");

            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "Orcamentos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "Cotacao",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "StatusCotacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCotacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusOrcamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOrcamentos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentos_StatusId",
                table: "Orcamentos",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Cotacao_StatusId",
                table: "Cotacao",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cotacao_StatusCotacoes_StatusId",
                table: "Cotacao",
                column: "StatusId",
                principalTable: "StatusCotacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamentos_StatusOrcamentos_StatusId",
                table: "Orcamentos",
                column: "StatusId",
                principalTable: "StatusOrcamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotacao_StatusCotacoes_StatusId",
                table: "Cotacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Orcamentos_StatusOrcamentos_StatusId",
                table: "Orcamentos");

            migrationBuilder.DropTable(
                name: "StatusCotacoes");

            migrationBuilder.DropTable(
                name: "StatusOrcamentos");

            migrationBuilder.DropIndex(
                name: "IX_Orcamentos_StatusId",
                table: "Orcamentos");

            migrationBuilder.DropIndex(
                name: "IX_Cotacao_StatusId",
                table: "Cotacao");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Cotacao");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Cotacao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
