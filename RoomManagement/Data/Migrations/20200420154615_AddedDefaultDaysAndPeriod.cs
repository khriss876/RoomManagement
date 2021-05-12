using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomManagement.Data.Migrations
{
    public partial class AddedDefaultDaysAndPeriod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "RoomTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DefaultDays",
                table: "RoomTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDays",
                table: "Bookings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "Bookings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomTypeId",
                table: "Bookings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DetailsRoomTypeViewModel",
                columns: table => new
                {
                    RoomTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(nullable: false),
                    RoomPrice = table.Column<int>(nullable: false),
                    RoomNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsRoomTypeViewModel", x => x.RoomTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomTypeId",
                table: "Bookings",
                column: "RoomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_RoomTypes_RoomTypeId",
                table: "Bookings",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "RoomTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_RoomTypes_RoomTypeId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "DetailsRoomTypeViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RoomTypeId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "DefaultDays",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "NumberOfDays",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "RoomTypeId",
                table: "Bookings");
        }
    }
}
