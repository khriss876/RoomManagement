using RoomManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagement.Data
{
    public class BookingRequest
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("EmployeeBookingRoomId")]
        public Employee EmployeeBookingRoom { get; set; }
        public string EmployeeBookingRoomId { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime DateActioned { get; set; }

        [ForeignKey("RoomTypeId")]
        public RoomType RoomType { get; set; }
        public int RoomTypeId { get; set; }
        public bool? BookingApproved { get; set; }
        [ForeignKey("BookingApprovedById")]
        public Employee ApprovedBy { get; set; }
        public bool? Approved { get; set; }
        public string BookingApprovedById { get; set; }

        


    }
}
