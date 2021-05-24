using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueMoonAdmin.Migrations
{
    public partial class RemoveMachineNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MachineNotes",
                table: "ServiceCustomers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MachineNotes",
                table: "ServiceCustomers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
