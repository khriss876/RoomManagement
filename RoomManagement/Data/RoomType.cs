using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagement.Data
{
    public class RoomType
    {
        [Key]
        public int RoomTypeId { get; set; }
        [Required]
        public string RoomName { get; set; }
        public int RoomPrice { get; set; }
        public int RoomNumber { get; set; }
        public int DefaultDays { get; set; }
        public DateTime DateCreated { get; set; }
       
    }
}
