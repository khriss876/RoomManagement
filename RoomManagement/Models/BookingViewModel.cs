using Microsoft.AspNetCore.Mvc.Rendering;
using RoomManagement.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagement.Models
{
    public class BookingViewModel
    {
            [Key]
            public int BookingId { get; set; }
            [Required]
            public DateTime BookingDate { get; set; }
            public int NumberOfDays { get; set; }
            public int Period { get; set; }

            [Required]
            public int BookingNumber { get; set; }
            public EmployeeViewModel Employee { get; set; }
            public string EmployeeId { get; set; }
            public RoomTypeViewModel RoomType { get; set; }
            public int RoomTypeId { get; set; }
            
        /*    public IEnumerable<SelectListItem> Employees { get; set; } // Creates drop down list for employees and room types
            public IEnumerable<SelectListItem> RoomTypes { get; set; }*/

    }

    public class CreateBookingViewModel
    {
        public int NumberUpdated { get; set; }
        public List<RoomTypeViewModel> RoomTypes { get; set; }
    }
    public class EditBookingViewModel
    {   [Key]
        public int BookingId { get; set; }
        public string EmployeeId { get; set; }
        public int NumberOfDays { get; set; }
        public RoomTypeViewModel RoomType { get; set; }
        public EmployeeViewModel Employee { get; set; }

    }

    public class ViewBookingViewModel
    {
        public EmployeeViewModel Employee { get; set; }
        public string EmployeeId { get; set; }
        //ITEMS IN LIST MIGHT NEED TO BE CHANGE IF YOU DONT GET CORRECT INFO WHEN PRINTED
        public List<BookingViewModel>BookingAllocations { get; set; }
    }
}
