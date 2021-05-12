using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomManagement.Data.Migrations
{
    public partial class ChangedBookingHistoryToBookingRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingHistories");

            migrationBuilder.DropTable(
                name: "DetailsRoomTypeViewModel");

            migrationBuilder.CreateTable(
                name: "BookingRequests",
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
                    table.PrimaryKey("PK_BookingRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingRequests_AspNetUsers_BookingApprovedById",
                        column: x => x.BookingApprovedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookingRequests_AspNetUsers_EmployeeBookingRoodId",
                        column: x => x.EmployeeBookingRoodId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookingRequests_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "RoomTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequests_BookingApprovedById",
                table: "BookingRequests",
                column: "BookingApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequests_EmployeeBookingRoodId",
                table: "BookingRequests",
                column: "EmployeeBookingRoodId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequests_RoomTypeId",
                table: "BookingRequests",
                column: "RoomTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingRequests");

            migrationBuilder.CreateTable(
                name: "BookingHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingApproved = table.Column<bool>(type: "bit", nullable: true),
                    BookingApprovedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeBookingRoodId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "DetailsRoomTypeViewModel",
                columns: table => new
                {
                    RoomTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    RoomPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsRoomTypeViewModel", x => x.RoomTypeId);
                });

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
        }
    }
}
