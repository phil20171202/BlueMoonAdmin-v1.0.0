using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueMoonAdmin.Migrations
{
    public partial class AddingContactDept : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactDepartment",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactDepartment",
                table: "Contacts");
        }
    }
}
