using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Web.Migrations
{
    public partial class updatingEmployeeModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Addresses_AddressId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalary_Employee_EmployeeId",
                table: "EmployeeSalary");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalaryPayment_Employee_EmployeeId",
                table: "EmployeeSalaryPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeSalaryPayment",
                table: "EmployeeSalaryPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeSalary",
                table: "EmployeeSalary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "EmployeeSalaryPayment",
                newName: "EmployeeSalaryPayments");

            migrationBuilder.RenameTable(
                name: "EmployeeSalary",
                newName: "EmployeeSalaries");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSalaryPayment_EmployeeId",
                table: "EmployeeSalaryPayments",
                newName: "IX_EmployeeSalaryPayments_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSalary_EmployeeId",
                table: "EmployeeSalaries",
                newName: "IX_EmployeeSalaries_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_AddressId",
                table: "Employees",
                newName: "IX_Employees_AddressId");

            migrationBuilder.AddColumn<string>(
                name: "Post",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeSalaryPayments",
                table: "EmployeeSalaryPayments",
                column: "PaymentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeSalaries",
                table: "EmployeeSalaries",
                column: "SalaryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Addresses_AddressId",
                table: "Employees",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalaries_Employees_EmployeeId",
                table: "EmployeeSalaries",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalaryPayments_Employees_EmployeeId",
                table: "EmployeeSalaryPayments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Addresses_AddressId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalaries_Employees_EmployeeId",
                table: "EmployeeSalaries");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalaryPayments_Employees_EmployeeId",
                table: "EmployeeSalaryPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeSalaryPayments",
                table: "EmployeeSalaryPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeSalaries",
                table: "EmployeeSalaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Post",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "EmployeeSalaryPayments",
                newName: "EmployeeSalaryPayment");

            migrationBuilder.RenameTable(
                name: "EmployeeSalaries",
                newName: "EmployeeSalary");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSalaryPayments_EmployeeId",
                table: "EmployeeSalaryPayment",
                newName: "IX_EmployeeSalaryPayment_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSalaries_EmployeeId",
                table: "EmployeeSalary",
                newName: "IX_EmployeeSalary_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_AddressId",
                table: "Employee",
                newName: "IX_Employee_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeSalaryPayment",
                table: "EmployeeSalaryPayment",
                column: "PaymentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeSalary",
                table: "EmployeeSalary",
                column: "SalaryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Addresses_AddressId",
                table: "Employee",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalary_Employee_EmployeeId",
                table: "EmployeeSalary",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalaryPayment_Employee_EmployeeId",
                table: "EmployeeSalaryPayment",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeID");
        }
    }
}
