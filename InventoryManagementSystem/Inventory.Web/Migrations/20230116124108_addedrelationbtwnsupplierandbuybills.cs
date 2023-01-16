using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Web.Migrations
{
    public partial class addedrelationbtwnsupplierandbuybills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierID",
                table: "BuyBills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuyBills_SupplierID",
                table: "BuyBills",
                column: "SupplierID");

            migrationBuilder.AddForeignKey(
                name: "FK_BuyBills_Suppliers_SupplierID",
                table: "BuyBills",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "SupplierID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuyBills_Suppliers_SupplierID",
                table: "BuyBills");

            migrationBuilder.DropIndex(
                name: "IX_BuyBills_SupplierID",
                table: "BuyBills");

            migrationBuilder.DropColumn(
                name: "SupplierID",
                table: "BuyBills");
        }
    }
}
