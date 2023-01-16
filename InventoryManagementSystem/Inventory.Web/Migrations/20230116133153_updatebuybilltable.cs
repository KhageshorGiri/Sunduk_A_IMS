using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Web.Migrations
{
    public partial class updatebuybilltable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BillDate",
                table: "BuyBills",
                newName: "VoucherDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "BillIssueDate",
                table: "BuyBills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "BuyBills",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PurchaseDate",
                table: "BuyBills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillIssueDate",
                table: "BuyBills");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "BuyBills");

            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "BuyBills");

            migrationBuilder.RenameColumn(
                name: "VoucherDate",
                table: "BuyBills",
                newName: "BillDate");
        }
    }
}
