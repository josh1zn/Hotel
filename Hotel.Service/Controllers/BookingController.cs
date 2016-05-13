using DataTransferObjects;
using Hotel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hotel.Service.Controllers
{
    public class BookingController : ApiController
    {
        private Booking book = new Booking();

        [HttpPost]
        public void Create(BookingDto booking)
        {
            book.Create(booking);
        }

        [HttpPost]
        public void Delete(int id)
        {
            book.Delete(id);
        }

        public BookingDto GetById(int id)
        {
            return book.GetById(id);
        }
        
        public List<BookingDto> GetBookings(int customerId, DateTime date)
        {
            return book.GetBookings(customerId, date).ToList();
        }

        public List<BookingDto> GetBookings(int customerId, int month, int year)
        {
            return book.GetBookings(customerId, month, year).ToList();
        }
    }
}
