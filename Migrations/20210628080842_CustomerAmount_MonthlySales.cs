using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueMoonAdmin.Migrations
{
    public partial class CustomerAmount_MonthlySales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "MonthlySalesFigure");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "MonthlySalesFigure");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "MonthlySalesFigure",
                newName: "Date");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "MonthlySalesFigure",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "MonthlySalesFigure",
                newName: "StartDate");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "MonthlySalesFigure",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "MonthlySalesFigure",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "MonthlySalesFigure",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
