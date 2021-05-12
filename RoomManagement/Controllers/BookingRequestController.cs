using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoomManagement.Contracts;
using RoomManagement.Data;
using RoomManagement.Models;

namespace RoomManagement.Controllers
{
    [Authorize]
    public class BookingRequestController : Controller
    {
        private readonly IBookingRequestRepository _bookingRequestRepo;
        private readonly IRoomTypeRepository _roomTypeRepo;
        private readonly IBookingRepository _bookingRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;

        public BookingRequestController(
            IBookingRequestRepository bookingRequestRepo,
            IRoomTypeRepository roomTypeRepo,
            IBookingRepository bookingRepo,
            IMapper mapper, 
            UserManager<Employee> userManager
            )
        {
            _bookingRequestRepo = bookingRequestRepo;
            _roomTypeRepo = roomTypeRepo;
            _mapper = mapper;
            _userManager = userManager;
            _bookingRepo = bookingRepo;
        }
        [Authorize(Roles = "Administrator")]
        // GET: BookingRequest
        public ActionResult Index()
        {
            var bookingRequests = _bookingRequestRepo.FindAll();
            var bookingRequestsModel = _mapper.Map<List<BookingRequestViewModel>>(bookingRequests);
            var model = new AdminBookingRequestViewModel
            {
            TotalRequests = bookingRequestsModel.Count,
            ApprovedRequests = bookingRequestsModel.Count(q => q.Approved == true),
            PendingRequests = bookingRequestsModel.Count(q => q.Approved == null),
            RejectedRequests = bookingRequestsModel.Count(q => q.Approved == false),
            BookingRequests = bookingRequestsModel 
            };
            return View(model);
        }

        public ActionResult MyBooking()
        {
            var employee = _userManager.GetUserAsync(User).Result;
            var employeeid = employee.Id;
            var employeeAllocations = _bookingRepo.GetBookingsByEmployee(employeeid);
            var employeeRequests = _bookingRequestRepo.GetBookingRequestsByEmployee(employeeid);

            var employeeAllocationsModel = _mapper.Map<List<BookingViewModel>>(employeeAllocations);
            var employeeRequestsModel = _mapper.Map<List<BookingRequestViewModel>>(employeeRequests);

            var model = new EmployeeBookingRequestViewModel
            {
                EmployeeBookings = employeeAllocationsModel,
                BookingRequests = employeeRequestsModel
            };
            return View(model);
        }
        // GET: BookingRequest/Details/5
        public ActionResult Details(int id)
        {
            var bookingrequest = _bookingRequestRepo.FindById(id);
            var model = _mapper.Map<BookingRequestViewModel>(bookingrequest);
            return View(model);
        }

        public ActionResult ApproveRequest(int id)
        {
            try
            {
                var user = _userManager.GetUserAsync(User).Result;
                var bookingrequest = _bookingRequestRepo.FindById(id);
                var employeeid = bookingrequest.EmployeeBookingRoomId;
                var roomtypeId = bookingrequest.RoomTypeId;
                var allocation = _bookingRepo.GetBookingsByEmployeeAndType(employeeid, roomtypeId);
                int daysRequested = (int)(bookingrequest.CheckOutDate - bookingrequest.CheckinDate).TotalDays;
                allocation.NumberOfDays = allocation.NumberOfDays - daysRequested;

                bookingrequest.Approved = true;
                bookingrequest.BookingApprovedById = user.Id;
                bookingrequest.DateActioned = DateTime.Now;

                 _bookingRequestRepo.Update(bookingrequest);
                _bookingRepo.Update(allocation);

                return RedirectToAction(nameof(Index));
                
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
                
            }
           
        }
            public ActionResult RejectRequest(int id)
               {
            try
            {
                var user = _userManager.GetUserAsync(User).Result;
                var bookingrequest = _bookingRequestRepo.FindById(id);
                bookingrequest.Approved = false;
                bookingrequest.BookingApprovedById = user.Id;
                bookingrequest.DateActioned = DateTime.Now;

               _bookingRequestRepo.Update(bookingrequest);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));

            }
             }
        // GET: BookingRequest/Create
        public ActionResult Create()
        {
            var roomTypes = _roomTypeRepo.FindAll();
            var roomTypeItems = roomTypes.Select(q => new SelectListItem {
                Text = q.RoomName,
                Value = q.RoomTypeId.ToString()
            });
            var model = new CreateBookingRequestViewModel
            {
                RoomType = roomTypeItems
            };
            return View(model);
        }

        // POST: BookingRequest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBookingRequestViewModel model)
        {
            
            try
            {
                var startDate = Convert.ToDateTime(model.CheckinDate);
                var endDate = Convert.ToDateTime(model.CheckOutDate);
                var roomTypes = _roomTypeRepo.FindAll();
                var roomTypeItems = roomTypes.Select(q => new SelectListItem
                {
                    Text = q.RoomName,
                    Value = q.RoomTypeId.ToString()
                });
                model.RoomType = roomTypeItems;
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                if(DateTime.Compare(startDate,endDate) > 1)
                {
                    ModelState.AddModelError("", "CheckinDate cannot be further than the CheckOutDate");
                    return View(model);
                }
                var employee = _userManager.GetUserAsync(User).Result;
                var allocation = _bookingRepo.GetBookingsByEmployeeAndType(employee.Id, model.RoomTypeId);//id to employee id 
                int daysRequested = (int)(startDate - endDate).TotalDays;
               
                if(daysRequested > allocation.NumberOfDays)
                {
                    ModelState.AddModelError("", "You do not have sufficient days to make this request");
                    return View(model);
                }

                var bookingRequestModel = new BookingRequestViewModel
                {
                    EmployeeBookingRoomId = employee.Id,
                    CheckinDate = startDate,
                    CheckOutDate = endDate,
                    Approved = null,
                    DateRequested = DateTime.Now,
                    DateActioned = DateTime.Now,
                    RoomTypeId = model.RoomTypeId
                };
                var bookingRequest = _mapper.Map<BookingRequest>(bookingRequestModel);
                var isSuccess = _bookingRequestRepo.Create(bookingRequest);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong WITH SUBMITTING RECORD");
                    return View(model);
                }
                return RedirectToAction("MyBooking");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(model);
            }
        }

        // GET: BookingRequest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookingRequest/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingRequest/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookingRequest/Delete/5
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