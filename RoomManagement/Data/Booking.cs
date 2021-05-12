using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagement.Data
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        public DateTime BookingDate { get; set; }
        public int BookingNumber { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        [ForeignKey("RoomTypeId")]
        public RoomType RoomType { get; set; }
        public int RoomTypeId { get; set; }
        public int Period { get; set; }

    }
}
