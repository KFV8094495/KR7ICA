using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Data.Migrations
{
    public partial class AddStaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Staff",
                schema: "thamco.events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StaffName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    contact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "staffing",
                schema: "thamco.events",
                columns: table => new
                {
                    StaffingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    staffId = table.Column<int>(nullable: true),
                    EventId = table.Column<int>(nullable: false),
                    Attended = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staffing", x => x.StaffingId);
                    table.ForeignKey(
                        name: "FK_staffing_Events_EventId",
                        column: x => x.EventId,
                        principalSchema: "thamco.events",
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_staffing_Staff_staffId",
                        column: x => x.staffId,
                        principalSchema: "thamco.events",
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_staffing_EventId",
                schema: "thamco.events",
                table: "staffing",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_staffing_staffId",
                schema: "thamco.events",
                table: "staffing",
                column: "staffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "staffing",
                schema: "thamco.events");

            migrationBuilder.DropTable(
                name: "Staff",
                schema: "thamco.events");
        }
    }
}
