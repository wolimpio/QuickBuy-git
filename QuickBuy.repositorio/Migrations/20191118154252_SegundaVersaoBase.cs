using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickBuy.repositorio.Migrations
{
    public partial class SegundaVersaoBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_UsuarioS_UsuarioId",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioS",
                table: "UsuarioS");

            migrationBuilder.RenameTable(
                name: "UsuarioS",
                newName: "Usuarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedidos_ProdutoId",
                table: "ItemPedidos",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPedidos_Produtos_ProdutoId",
                table: "ItemPedidos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPedidos_Produtos_ProdutoId",
                table: "ItemPedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioId",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_ItemPedidos_ProdutoId",
                table: "ItemPedidos");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "UsuarioS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioS",
                table: "UsuarioS",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_UsuarioS_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId",
                principalTable: "UsuarioS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
