using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomManagement.Data.Migrations
{
    public partial class FixedBookingRequestDataClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "BookingRequests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateActioned",
                table: "BookingRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRequested",
                table: "BookingRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "EmployeeViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypeViewModel",
                columns: table => new
                {
                    RoomTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DefaultDays = table.Column<int>(nullable: false),
                    RoomPrice = table.Column<int>(nullable: false),
                    RoomNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypeViewModel", x => x.RoomTypeId);
                });

            migrationBuilder.CreateTable(
                name: "BookingRequestViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeBookingRoomId = table.Column<string>(nullable: true),
                    CheckinDate = table.Column<DateTime>(nullable: false),
                    CheckOutDate = table.Column<DateTime>(nullable: false),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    DateRequested = table.Column<DateTime>(nullable: false),
                    DateActioned = table.Column<DateTime>(nullable: false),
                    RoomTypeId = table.Column<int>(nullable: false),
                    BookingApproved = table.Column<bool>(nullable: true),
                    ApprovedById = table.Column<string>(nullable: true),
                    BookingApprovedById = table.Column<string>(nullable: true),
                    Approved = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingRequestViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingRequestViewModel_EmployeeViewModel_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "EmployeeViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookingRequestViewModel_EmployeeViewModel_EmployeeBookingRoomId",
                        column: x => x.EmployeeBookingRoomId,
                        principalTable: "EmployeeViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookingRequestViewModel_RoomTypeViewModel_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypeViewModel",
                        principalColumn: "RoomTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequestViewModel_ApprovedById",
                table: "BookingRequestViewModel",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequestViewModel_EmployeeBookingRoomId",
                table: "BookingRequestViewModel",
                column: "EmployeeBookingRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequestViewModel_RoomTypeId",
                table: "BookingRequestViewModel",
                column: "RoomTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingRequestViewModel");

            migrationBuilder.DropTable(
                name: "EmployeeViewModel");

            migrationBuilder.DropTable(
                name: "RoomTypeViewModel");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "BookingRequests");

            migrationBuilder.DropColumn(
                name: "DateActioned",
                table: "BookingRequests");

            migrationBuilder.DropColumn(
                name: "DateRequested",
                table: "BookingRequests");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}
