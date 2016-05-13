using DataTransferObjects;
using Hotel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Http.Results;

namespace Hotel.Service.Controllers
{
    public class CustomerController : ApiController
    {
        private Customer cust = new Customer();

        [HttpPost]
        public int Create(CustomerDto customer)
        {
            return cust.Create(customer); 
        }

        [HttpPost]
        public void Update(CustomerDto customer)
        {
            cust.Update(customer);
        }

        [HttpPost]
        public void Delete(int id)
        {
            cust.Delete(id);
        }

        [HttpGet]
        public CustomerDto GetById(int id)
        {
            return cust.GetById(id);
        }

        [HttpPost]
        public List<CustomerDto> GetCustomers(string name)
        {
            return cust.GetAllByNameOrSurname(name).ToList();
        }

        [HttpGet]
        public JsonResult<CustomerDto> GetByIdJson(int id)
        {
            return Json<CustomerDto>(cust.GetById(id));
        }

        [HttpPost]
        public JsonResult<List<CustomerDto>> GetCustomersJson(string name)
        {
            return Json<List<CustomerDto>>(cust.GetAllByNameOrSurname(name).ToList());
        }
    }
}
