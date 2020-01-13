using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Data.Migrations
{
    public partial class updateEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "FoodCost",
                schema: "thamco.events",
                table: "Events",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Menu",
                schema: "thamco.events",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VenueCost",
                schema: "thamco.events",
                table: "Events",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodCost",
                schema: "thamco.events",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Menu",
                schema: "thamco.events",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "VenueCost",
                schema: "thamco.events",
                table: "Events");
        }
    }
}
