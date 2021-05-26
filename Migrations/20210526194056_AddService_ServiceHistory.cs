using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueMoonAdmin.Migrations
{
    public partial class AddService_ServiceHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "MonthlySalesFigure",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EngineerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServceComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceHistory_ServiceCustomers_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "ServiceCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHistory_ServiceId",
                table: "ServiceHistory",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceHistory");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "MonthlySalesFigure");
        }
    }
}
