using RoomManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagement.Contracts
{
   public interface IBookingRequestRepository : IRepositoryBase <BookingRequest>
    {
        ICollection<BookingRequest> GetBookingRequestsByEmployee(string employeeid);
    }
}
