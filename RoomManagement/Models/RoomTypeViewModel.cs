using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagement.Models
{
    public class RoomTypeViewModel
    {   [Key]
        public int RoomTypeId { get; set; }
        [Required]
        public string RoomName { get; set; }
        public DateTime? DateCreated { get; set; }
        [Required]
        [Display(Name = "Default Numebr Of Days")]
        [Range(1,30, ErrorMessage = " Please Enter A Valid Number")]
        public int DefaultDays { get; set; }
        public int RoomPrice { get; set; }
        public int RoomNumber { get; set; }
    }
 
}
