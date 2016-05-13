using DataTransferObjects;
using Hotel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class BookingController : Controller
    {
        private BookingClient bc = new BookingClient();

        // GET: Booking
        public ActionResult Index(DateTime? date, int customerId = 0)
        {
            date = (date == null) ? DateTime.Now : date;
            var bookings = bc.GetBookings(customerId, date.Value);
            return View(bookings);
        }

        public ActionResult Create()
        {
            var customer = Session["Customer"] as CustomerDto ?? new CustomerDto();
            return View(customer);
        }

        [HttpPost]
        public ActionResult Create(BookingDto booking)
        {
            bc.Create(booking);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var booking = bc.GetById(id);
            return View(booking);
        }

        [HttpPost]
        public ActionResult PostDelete(int id)
        {
            bc.Delete(id);
            return RedirectToAction("Index");
        }

        public JsonResult GetBookings(int customerId, int month = 0, int year = 0)
        {
            var bookings = bc.GetBookings(customerId, month, year);
            return Json(bookings, JsonRequestBehavior.AllowGet);
        }
    }
}