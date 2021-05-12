using RoomManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagement.Contracts
{
    public interface IRoomTypeRepository : IRepositoryBase <RoomType>
    {
        ICollection<RoomType> GetEmployeeByRoomType(int Id);
    }
}
