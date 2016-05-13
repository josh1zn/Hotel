using DataTransferObjects;
using Hotel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerClient cc = new CustomerClient();

        // GET: Customer
        public ActionResult Index()
        {
            var customers = cc.GetCustomers("");
            return View(customers);
        }

        [HttpPost]
        public ActionResult Index(string searchterm)
        {
            var customers = cc.GetCustomers(searchterm);
            return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var customer = cc.GetById(id);
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create(bool goToCreateBooking = false)
        {
            ViewBag.GoToCreateBooking = goToCreateBooking;
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(CustomerDto customer, bool goToCreateBooking = false)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    customer.Id = cc.Create(customer);
                    if(goToCreateBooking)
                    {
                        Session["Customer"] = customer;
                        return RedirectToAction("Create", "Booking");
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(customer);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = cc.GetById(id);
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(CustomerDto customer)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    cc.Update(customer);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(customer);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = cc.GetById(id);
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                cc.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public JsonResult GetCustomers(string name)
        {
            var customers = cc.GetCustomers(name);
            return Json(customers, JsonRequestBehavior.AllowGet);
        }
    }
}
