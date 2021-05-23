using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueMoonAdmin.Migrations
{
    public partial class MovedServiceToServiceCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "ServiceCustomers");

            migrationBuilder.DropColumn(
                name: "CurrentMachine",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastServiceDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Service",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ServiceContract",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "TelephoneNumber",
                table: "ServiceCustomers",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "ContractType",
                table: "ServiceCustomers",
                newName: "ServiceContract");

            migrationBuilder.RenameColumn(
                name: "ContactName",
                table: "ServiceCustomers",
                newName: "MachineNotes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "ServiceCustomers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RenewalDate",
                table: "ServiceCustomers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastServiceDate",
                table: "ServiceCustomers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "Service",
                table: "ServiceCustomers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCustomers_CustomerId",
                table: "ServiceCustomers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCustomers_Customers_CustomerId",
                table: "ServiceCustomers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCustomers_Customers_CustomerId",
                table: "ServiceCustomers");

            migrationBuilder.DropIndex(
                name: "IX_ServiceCustomers_CustomerId",
                table: "ServiceCustomers");

            migrationBuilder.DropColumn(
                name: "Service",
                table: "ServiceCustomers");

            migrationBuilder.RenameColumn(
                name: "ServiceContract",
                table: "ServiceCustomers",
                newName: "ContractType");

            migrationBuilder.RenameColumn(
                name: "MachineNotes",
                table: "ServiceCustomers",
                newName: "ContactName");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "ServiceCustomers",
                newName: "TelephoneNumber");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "ServiceCustomers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RenewalDate",
                table: "ServiceCustomers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastServiceDate",
                table: "ServiceCustomers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "ServiceCustomers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentMachine",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastServiceDate",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Service",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ServiceContract",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
