using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Data.Migrations
{
    public partial class updateStaffing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                schema: "thamco.events",
                table: "StaffBooking");

            migrationBuilder.DropColumn(
                name: "Location",
                schema: "thamco.events",
                table: "StaffBooking");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "thamco.events",
                table: "StaffBooking");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "thamco.events",
                table: "StaffBooking",
                newName: "StaffId");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                schema: "thamco.events",
                table: "StaffBooking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StaffId1",
                schema: "thamco.events",
                table: "StaffBooking",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffBooking_EventId",
                schema: "thamco.events",
                table: "StaffBooking",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffBooking_StaffId1",
                schema: "thamco.events",
                table: "StaffBooking",
                column: "StaffId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffBooking_Events_EventId",
                schema: "thamco.events",
                table: "StaffBooking",
                column: "EventId",
                principalSchema: "thamco.events",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffBooking_Staff_StaffId1",
                schema: "thamco.events",
                table: "StaffBooking",
                column: "StaffId1",
                principalSchema: "thamco.events",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffBooking_Events_EventId",
                schema: "thamco.events",
                table: "StaffBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffBooking_Staff_StaffId1",
                schema: "thamco.events",
                table: "StaffBooking");

            migrationBuilder.DropIndex(
                name: "IX_StaffBooking_EventId",
                schema: "thamco.events",
                table: "StaffBooking");

            migrationBuilder.DropIndex(
                name: "IX_StaffBooking_StaffId1",
                schema: "thamco.events",
                table: "StaffBooking");

            migrationBuilder.DropColumn(
                name: "EventId",
                schema: "thamco.events",
                table: "StaffBooking");

            migrationBuilder.DropColumn(
                name: "StaffId1",
                schema: "thamco.events",
                table: "StaffBooking");

            migrationBuilder.RenameColumn(
                name: "StaffId",
                schema: "thamco.events",
                table: "StaffBooking",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                schema: "thamco.events",
                table: "StaffBooking",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Location",
                schema: "thamco.events",
                table: "StaffBooking",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "thamco.events",
                table: "StaffBooking",
                nullable: true);
        }
    }
}
