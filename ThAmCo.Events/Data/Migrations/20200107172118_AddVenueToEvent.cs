using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Data.Migrations
{
    public partial class AddVenueToEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VenueCode",
                schema: "thamco.events",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VenueReference",
                schema: "thamco.events",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VenueCode",
                schema: "thamco.events",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "VenueReference",
                schema: "thamco.events",
                table: "Events");
        }
    }
}
