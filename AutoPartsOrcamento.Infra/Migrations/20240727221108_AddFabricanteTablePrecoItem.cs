using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPartsOrcamento.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddFabricanteTablePrecoItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fabricante",
                table: "PrecoItemCotacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fabricante",
                table: "PrecoItemCotacoes");
        }
    }
}
