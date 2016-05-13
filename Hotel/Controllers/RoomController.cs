using DataTransferObjects;
using Hotel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class RoomController : Controller
    {
        private RoomClient rc = new RoomClient();
        // GET: Room
        public ActionResult Index()
        {
            var rooms = rc.GetAllRooms();
            return View(rooms);
        }

        [HttpGet]
        public ActionResult Availability(DateTime? startDate, DateTime? endDate)
        {
            if(startDate == null || endDate == null)
            {
                startDate = endDate = DateTime.Now;
            }
            ViewBag.StartDate = startDate.Value;
            ViewBag.EndDate = endDate.Value;
            var rooms = rc.GetAvailable(startDate.Value, endDate.Value);
            return View(rooms);
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        [HttpPost]
        public ActionResult Create(RoomDto room)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    rc.CreateRoom(room);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(room);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int id)
        {
            var room = rc.GetById(id);
            return View(room);
        }

        // POST: Room/Edit/5
        [HttpPost]
        public ActionResult Edit(RoomDto room)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    rc.Update(room);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(room);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var room = rc.GetById(id);
            return View(room);
        }

        // POST: Room/Delete/5
        [HttpPost]
        public ActionResult PostDelete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                rc.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public JsonResult GetById(int id)
        {
            var room = rc.GetById(id);
            return Json(room, JsonRequestBehavior.AllowGet);
        }
    }
}
