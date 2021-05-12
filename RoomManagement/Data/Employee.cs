using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagement.Data
{
    public class Employee : IdentityUser
    {//IF THERE IS AN ERROR WITH AUTOMAPPING THEN CHANGE EMPLOYEEID VARIABLE TO TYPE STRING
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }


    }

}
