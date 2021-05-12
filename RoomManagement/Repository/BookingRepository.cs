using Microsoft.EntityFrameworkCore;
using RoomManagement.Contracts;
using RoomManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagement.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _db;
        public BookingRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CheckAllocation(int roomtypeid, string employeeid)
        {
            var period = DateTime.Now.Year;
            return FindAll().Where(q => q.EmployeeId == employeeid && q.RoomTypeId == roomtypeid && q.Period == period).Any();
        
          
         }

        public bool Create(Booking entity)
        {
            _db.Bookings.Add(entity);
            return Save();
        }

        public bool Delete(Booking entity)
        {
            _db.Bookings.Remove(entity);
            return Save();
        }

        public ICollection<Booking> FindAll()
        {
            var bookings = _db.Bookings
                .Include(q => q.RoomType)
                .Include(q => q.Employee)
                .ToList();
            return bookings;
        }

        public Booking FindById(int id)
        {//ID MAY NEED TO BE CHANGE VARIABLE AND IN DB CONTEXT
            var bookings = _db.Bookings
                .Include(q => q.RoomType)
                .Include(q => q.Employee)
                .FirstOrDefault(q => q.BookingId == id);//Id might be wrong
                
            return bookings;
        }

        public ICollection<Booking> GetBookingsByEmployee(string employeeid)
        {
            var period = DateTime.Now.Year;
            return FindAll()
                .Where(q => q.EmployeeId == employeeid && q.Period == period)
                .ToList();
        }

        public Booking GetBookingsByEmployeeAndType(string employeeid, int roomtypeid)
        {
            var period = DateTime.Now.Year;
            return FindAll()
                .FirstOrDefault(q => q.EmployeeId == employeeid && q.Period == period && q.RoomTypeId == roomtypeid);
                
        }

        public bool isExists(int Id)
        {
            var exists = _db.Bookings.Any(q => q.BookingId == Id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Booking entity)
        {
            _db.Bookings.Update(entity);
            return Save();
        }
    }
}
