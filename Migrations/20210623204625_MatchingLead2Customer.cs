using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueMoonAdmin.Migrations
{
    public partial class MatchingLead2Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WebAddress",
                table: "Leads",
                newName: "Website");

            migrationBuilder.AddColumn<string>(
                name: "Vat",
                table: "Leads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WasLead",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vat",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "WasLead",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Website",
                table: "Leads",
                newName: "WebAddress");
        }
    }
}
