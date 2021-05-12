using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomManagement.Contracts;
using RoomManagement.Data;
using RoomManagement.Models;

namespace RoomManagement.Controllers
{
   
    public class RoomTypeController : Controller
    {
        private readonly IRoomTypeRepository _repo;
        private readonly IMapper _mapper;

        public RoomTypeController(IRoomTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        
        // GET: RoomType
        public ActionResult Index()
        {
            var roomtypes = _repo.FindAll().ToList();
            var model = _mapper.Map<List<RoomType>, List<RoomTypeViewModel>>(roomtypes);
            return View(model);
        }

        // GET: RoomType/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {

                return NotFound();
            }
            var roomtype = _repo.FindById(id);
            var model = _mapper.Map<RoomTypeViewModel>(roomtype);

            return View(model);
        }

        // GET: RoomType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomTypeViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid) 
                {
                    return View(model);
                }
                var roomtype = _mapper.Map<RoomType>(model);
                var isSuccess =_repo.Create(roomtype);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went Wrong...");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went Wrong...");
                return View(model);
            }
        }

        // GET: RoomType/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
                return NotFound();
            var roomtype = _repo.FindById(id);
            var model = _mapper.Map<RoomTypeViewModel>(roomtype);
            return View(model);
        }

        // POST: RoomType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoomTypeViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var roomtype = _mapper.Map<RoomType>(model);
                var isSuccess = _repo.Update(roomtype);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went Wrong...");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went Wrong...");
                return View(model);
            }
        }
        [Authorize(Roles ="Administrator")]
        // GET: RoomType/Delete/5
        public ActionResult Delete(int id)
        {
            var roomtype = _repo.FindById(id);
            if (roomtype == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(roomtype);
            if (!isSuccess)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: RoomType/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RoomTypeViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                var roomtype = _repo.FindById(id);
                if(roomtype == null)
                {
                    return NotFound();
                }
                var isSuccess = _repo.Delete(roomtype);
                if (!isSuccess)
                {
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }
    }
}