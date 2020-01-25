using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickBuy.repositorio.Migrations
{
    public partial class AjusteColunaEnderecoCompleto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumeroEndereço",
                table: "Pedidos",
                newName: "NumeroEndereco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumeroEndereco",
                table: "Pedidos",
                newName: "NumeroEndereço");
        }
    }
}
