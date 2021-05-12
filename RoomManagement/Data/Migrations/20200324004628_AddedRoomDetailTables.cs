using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomManagement.Data.Migrations
{
    public partial class AddedRoomDetailTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    BookingNumber = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
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
                    table.PrimaryKey("PK_RoomTypes", x => x.RoomTypeId);
                });

            migrationBuilder.CreateTable(
                name: "BookedRooms",
                columns: table => new
                {
                    BookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(nullable: false),
                    CheckinDate = table.Column<DateTime>(nullable: false),
                    CheckOutDate = table.Column<DateTime>(nullable: false),
                    RoomStatus = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true),
                    RoomTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedRooms", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_BookedRooms_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookedRooms_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "RoomTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeBookingRoodId = table.Column<string>(nullable: true),
                    CheckinDate = table.Column<DateTime>(nullable: false),
                    CheckOutDate = table.Column<DateTime>(nullable: false),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    RoomTypeId = table.Column<int>(nullable: false),
                    BookingApproved = table.Column<bool>(nullable: true),
                    BookingApprovedById = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingHistories_AspNetUsers_BookingApprovedById",
                        column: x => x.BookingApprovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookingHistories_AspNetUsers_EmployeeBookingRoodId",
                        column: x => x.EmployeeBookingRoodId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookingHistories_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "RoomTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookedRooms_EmployeeId",
                table: "BookedRooms",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BookedRooms_RoomTypeId",
                table: "BookedRooms",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHistories_BookingApprovedById",
                table: "BookingHistories",
                column: "BookingApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHistories_EmployeeBookingRoodId",
                table: "BookingHistories",
                column: "EmployeeBookingRoodId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHistories_RoomTypeId",
                table: "BookingHistories",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_EmployeeId",
                table: "Bookings",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookedRooms");

            migrationBuilder.DropTable(
                name: "BookingHistories");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}
