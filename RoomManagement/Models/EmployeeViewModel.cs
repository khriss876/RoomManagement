using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagement.Models
{
    public class EmployeeViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
