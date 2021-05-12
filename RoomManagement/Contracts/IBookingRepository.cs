using RoomManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagement.Contracts
{
    public interface IBookingRepository :IRepositoryBase < Booking >
    {
        bool CheckAllocation(int roomtypeid, string employeeid);
        ICollection<Booking> GetBookingsByEmployee(string employeeid);
        Booking GetBookingsByEmployeeAndType(string employeeid, int roomtypeid);
    }
}
