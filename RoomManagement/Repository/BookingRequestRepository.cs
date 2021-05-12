using Microsoft.EntityFrameworkCore;
using RoomManagement.Contracts;
using RoomManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomManagement.Repository
{
    public class BookingRequestRepository : IBookingRequestRepository
    {
        private readonly ApplicationDbContext _db;
        public BookingRequestRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(BookingRequest entity)
        {
            _db.BookingRequests.Add(entity);
            return Save();
        }

        public bool Delete(BookingRequest entity)
        {
            _db.BookingRequests.Remove(entity);
            return Save();
        }

        public ICollection<BookingRequest> FindAll()
        {
            var BookingHistory = _db.BookingRequests
                .Include(q => q.EmployeeBookingRoom)
                .Include(q => q.ApprovedBy)
                .Include(q => q.RoomType)
                .ToList();
            return BookingHistory;
        }

        public BookingRequest FindById(int id)
        {
            var BookingHistory = _db.BookingRequests
                .Include(q => q.EmployeeBookingRoom)
                .Include(q => q.ApprovedBy)
                .Include(q => q.RoomType)
                .FirstOrDefault(q => q.Id == id);
            return BookingHistory;
        }

        public ICollection<BookingRequest> GetBookingRequestsByEmployee(string employeeid)
        {
            var BookingHistory = FindAll()
                .Where(q => q.EmployeeBookingRoomId == employeeid)
                .ToList();
            return BookingHistory;
        }

        public bool isExists(int Id)
        {
            var exists = _db.BookingRequests.Any(q => q.Id == Id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(BookingRequest entity)
        {
            _db.BookingRequests.Update(entity);
            return Save();
        }
    }
}
