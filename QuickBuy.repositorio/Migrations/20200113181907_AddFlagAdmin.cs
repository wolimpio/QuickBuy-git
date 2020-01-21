using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickBuy.repositorio.Migrations
{
    public partial class AddFlagAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Admin",
                table: "Usuarios",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin",
                table: "Usuarios");
        }
    }
}
