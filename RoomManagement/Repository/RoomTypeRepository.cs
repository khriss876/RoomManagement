using RoomManagement.Contracts;
using RoomManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagement.Repository
{

    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public RoomTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(RoomType entity)
        {//ADDING CONTENT TO DATABASE, DO THIS FOR EVERY REPOSITROY
            //SAVE
            _db.RoomTypes.Add(entity);
            return Save();
        }

        public bool Delete(RoomType entity)
        {
            _db.RoomTypes.Remove(entity);
            return Save();
        }

        public ICollection<RoomType> FindAll()
        {
            var roomTypes = _db.RoomTypes.ToList();
            return roomTypes;
        }

        public RoomType FindById(int id)
        {
            var roomType = _db.RoomTypes.Find(id);
            return roomType;
        }

        public ICollection<RoomType> GetEmployeeByRoomType(int Id)
        {
            throw new NotImplementedException();
        }

        public bool isExists(int Id)
        {
            var exists = _db.RoomTypes.Any(q => q.RoomTypeId ==Id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(RoomType entity)
        {
            _db.RoomTypes.Update(entity);
            return Save();
        }
    }
}
