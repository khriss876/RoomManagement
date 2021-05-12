using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomManagement.Data.Migrations
{
    public partial class FixedColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingRequests_AspNetUsers_EmployeeBookingRoodId",
                table: "BookingRequests");

            migrationBuilder.DropIndex(
                name: "IX_BookingRequests_EmployeeBookingRoodId",
                table: "BookingRequests");

            migrationBuilder.DropColumn(
                name: "EmployeeBookingRoodId",
                table: "BookingRequests");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeBookingRoomId",
                table: "BookingRequests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequests_EmployeeBookingRoomId",
                table: "BookingRequests",
                column: "EmployeeBookingRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingRequests_AspNetUsers_EmployeeBookingRoomId",
                table: "BookingRequests",
                column: "EmployeeBookingRoomId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingRequests_AspNetUsers_EmployeeBookingRoomId",
                table: "BookingRequests");

            migrationBuilder.DropIndex(
                name: "IX_BookingRequests_EmployeeBookingRoomId",
                table: "BookingRequests");

            migrationBuilder.DropColumn(
                name: "EmployeeBookingRoomId",
                table: "BookingRequests");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeBookingRoodId",
                table: "BookingRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequests_EmployeeBookingRoodId",
                table: "BookingRequests",
                column: "EmployeeBookingRoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingRequests_AspNetUsers_EmployeeBookingRoodId",
                table: "BookingRequests",
                column: "EmployeeBookingRoodId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
