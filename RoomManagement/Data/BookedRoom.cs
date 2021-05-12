using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagement.Data
{
    public class BookedRoom
    {
        [Key]
        public int BookingId { get; set; }
        public int RoomNumber { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string RoomStatus { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        [ForeignKey("RoomTypeId")]
        public RoomType RoomType { get; set; }
        public int RoomTypeId { get; set; }


    }
}
