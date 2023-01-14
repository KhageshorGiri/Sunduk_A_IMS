using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Web.Migrations
{
    public partial class updatingSupplierTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "Rate");

            migrationBuilder.AddColumn<string>(
                name: "PanNumber",
                table: "Suppliers",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PanNumber",
                table: "Suppliers");

            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "Products",
                newName: "Price");
        }
    }
}
