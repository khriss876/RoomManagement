using RoomManagement.Contracts;
using RoomManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagement.Repository
{
    public class BookedRoomRepository : IBookedRoomRepository
    {
        private readonly ApplicationDbContext _db;
        public BookedRoomRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(BookedRoom entity)
        {
            _db.BookedRooms.Add(entity);
            return Save();
        }

        public bool Delete(BookedRoom entity)
        {
            _db.BookedRooms.Remove(entity);
            return Save();
        }

        public ICollection<BookedRoom> FindAll()
        {
            var bookedroom = _db.BookedRooms.ToList();
            return bookedroom;
        }

        public BookedRoom FindById(int id)
        {
            var bookedroom = _db.BookedRooms.Find(id);
            return bookedroom;
        }

        public bool isExists(int Id)
        {
            var exists = _db.BookedRooms.Any(q => q.BookingId == Id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(BookedRoom entity)
        {
            _db.BookedRooms.Update(entity);
            return Save();
        }
    }
}
