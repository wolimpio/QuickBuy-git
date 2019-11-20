using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickBuy.repositorio.Migrations
{
    public partial class CargaFormaPagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Formapagamento",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, "Descrição Não Definido", "Não Definido" },
                    { 2, "Descrição Boleto", "Boleto" },
                    { 3, "Descrição Cartão de Crédito", "Cartão de Crédito" },
                    { 4, "Descrição Depósito", "Depósito" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Formapagamento",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Formapagamento",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Formapagamento",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Formapagamento",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
