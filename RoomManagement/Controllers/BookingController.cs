using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RoomManagement.Contracts;
using RoomManagement.Data;
using RoomManagement.Models;

namespace RoomManagement.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class BookingController : Controller
    {
        private readonly IRoomTypeRepository _roomrepo;
        private readonly IBookingRepository _bookrepo;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;
        public BookingController(
            IRoomTypeRepository roomrepo,
            IBookingRepository bookrepo, 
            IMapper mapper,
            UserManager<Employee> userManager

            )
        {
            _roomrepo = roomrepo;
            _bookrepo = bookrepo;
            _mapper = mapper;
            _userManager = userManager;
        }
        // GET: Booking
        public ActionResult Index()
        {
            var roomtypes = _roomrepo.FindAll().ToList();
            var mappedRoomTypes = _mapper.Map<List<RoomType>, List<RoomTypeViewModel>>(roomtypes);
            var model = new CreateBookingViewModel
            {
                RoomTypes = mappedRoomTypes,
                NumberUpdated = 0
            
            };
            
            return View(model);
            
        }
        public ActionResult SetRoom(int id)
        {
            var roomtype = _roomrepo.FindById(id);
            var employees = _userManager.GetUsersInRoleAsync("Employee").Result;
           
            foreach (var emp in employees)
            {
                if (_bookrepo.CheckAllocation(id, emp.Id))
                    continue;
                var allocation = new BookingViewModel
                {
                    // BookingDate is the same as DateCreated
                    BookingDate = DateTime.Now,
                    EmployeeId = emp.Id,
                    RoomTypeId = id,
                    NumberOfDays = roomtype.DefaultDays,
                    Period = DateTime.Now.Year

                };
                var roomallocation = _mapper.Map<Booking>(allocation);
                _bookrepo.Create(roomallocation);
            }
            return RedirectToAction(nameof(Index));
        }
        public ActionResult ListEmployees()
        {
            var employees = _userManager.GetUsersInRoleAsync("Employee").Result;
            var model = _mapper.Map<List<EmployeeViewModel>>(employees);
            return View(model);
        }
        // GET: Booking/Details/5
        public ActionResult Details(string id)
        {
            var employee = _mapper.Map<EmployeeViewModel>(_userManager.FindByIdAsync(id).Result);
           // var period = DateTime.Now.Year;
            var allocations = _mapper.Map<List<BookingViewModel>>(_bookrepo.GetBookingsByEmployee(id)); //bookrepo might need to be changed to roomredo
            var model = new ViewBookingViewModel{
                Employee = employee,
                BookingAllocations = allocations
            };
            return View(model);
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int id)
        {
            var bookingallocation = _bookrepo.FindById(id);
            var model = _mapper.Map<EditBookingViewModel>(bookingallocation);
            return View(model);
        }

        // POST: Booking/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditBookingViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var record = _bookrepo.FindById(model.BookingId);
                record.NumberOfDays = model.NumberOfDays;
                var isSuccess = _bookrepo.Update(record);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Error while saving");
                    return View(model);

                }

                return RedirectToAction(nameof(Details), new {id = model.EmployeeId});
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Booking/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}