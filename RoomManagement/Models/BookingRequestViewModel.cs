using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagement.Models
{
    public class BookingRequestViewModel
    {


        public int Id { get; set; }
        public EmployeeViewModel EmployeeBookingRoom { get; set; }
        public string EmployeeBookingRoomId { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime DateActioned { get; set; }
        public RoomTypeViewModel RoomType { get; set; }
        public BookingRequestViewModel NumberOfDays { get; set; }
        public bool Cancelled { get; set; }
        public int RoomTypeId { get; set; }
        public bool? BookingApproved { get; set; }
        public EmployeeViewModel ApprovedBy { get; set; }
        public string BookingApprovedById { get; set; }
        public bool? Approved { get; set; }
    }
    public class AdminBookingRequestViewModel
    {
        [Display(Name = "Total Number of Requests")]
        public int TotalRequests { get; set; }
        [Display(Name = " Approved Requests ")]
        public int ApprovedRequests { get; set; }
        [Display(Name = "Pending Requests")]
        public int PendingRequests { get; set; }
        [Display(Name = "Rejected Requests")]
        public int RejectedRequests { get; set; }
        public List<BookingRequestViewModel> BookingRequests { get; set; }
    }
    public class CreateBookingRequestViewModel
    {
        [Display(Name = "CheckinDate")]
        [Required]     
        public string CheckinDate { get; set; }
        [Display(Name = "CheckOutDate")]
        [Required]
        public string CheckOutDate { get; set; }
        public IEnumerable<SelectListItem> RoomType { get; set; }
        [Display(Name = "Room Type")]
        public int RoomTypeId { get; set; }




    }
    public class EmployeeBookingRequestViewModel
    {
        public List<BookingViewModel> EmployeeBookings { get; set; }
        public List<BookingRequestViewModel> BookingRequests { get; set; }
    }
}
