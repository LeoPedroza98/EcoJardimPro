using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoJardimProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoNomeOrcamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descrição",
                table: "Servicos",
                newName: "Descricao");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Orcamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Orcamentos");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Servicos",
                newName: "Descrição");
        }
    }
}
