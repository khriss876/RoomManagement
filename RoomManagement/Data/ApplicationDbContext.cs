using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoomManagement.Models;

namespace RoomManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<BookedRoom> BookedRooms { get; set; }
        public DbSet<BookingRequest> BookingRequests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<RoomManagement.Models.BookingRequestViewModel> BookingRequestViewModel { get; set; }
       // public DbSet<RoomManagement.Models.RoomTypeViewModel> DetailsRoomTypeViewModel { get; set; }
       // public DbSet<RoomManagement.Models.EmployeeViewModel> EmployeeViewModel { get; set; }
        //public DbSet<RoomManagement.Models.BookingViewModel> BookingViewModel { get; set; }
        //public DbSet<RoomManagement.Models.EditBookingViewModel> EditBookingViewModel { get; set; }

    }
}
