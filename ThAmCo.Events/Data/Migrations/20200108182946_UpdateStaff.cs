using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Data.Migrations
{
    public partial class UpdateStaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "contact",
                schema: "thamco.events",
                table: "Staff",
                newName: "Contact");

            migrationBuilder.RenameColumn(
                name: "StaffName",
                schema: "thamco.events",
                table: "Staff",
                newName: "SurName");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "thamco.events",
                table: "Staff",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "thamco.events",
                table: "Staff",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "thamco.events",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "thamco.events",
                table: "Staff");

            migrationBuilder.RenameColumn(
                name: "Contact",
                schema: "thamco.events",
                table: "Staff",
                newName: "contact");

            migrationBuilder.RenameColumn(
                name: "SurName",
                schema: "thamco.events",
                table: "Staff",
                newName: "StaffName");
        }
    }
}
