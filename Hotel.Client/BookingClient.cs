using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Client
{
    public class BookingClient : BaseClient
    {
        public void Create(BookingDto booking)
        {
            param.Clear();
            param["booking"] = booking;
            Post("Booking/Create");
        }

        public void Delete(int id)
        {
            param.Clear();
            param["id"] = id;
            Post("Booking/Delete");
        }

        public BookingDto GetById(int id)
        {
            param.Clear();
            param["id"] = id;
            var response = Get<BookingDto>("Booking/GetById");
            return response.Data;
        }

        public List<BookingDto> GetBookings(int customerId, DateTime date)
        {
            param.Clear();
            param["customerId"] = customerId;
            param["date"] = date;
            var response = Get<List<BookingDto>>("Booking/GetBookings");
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
                return new List<BookingDto>();
            }
        }

        public List<BookingDto> GetBookings(int customerId, int month, int year)
        {
            param.Clear();
            param["customerId"] = customerId;
            param["month"] = month;
            param["year"] = year;
            var response = Get<List<BookingDto>>("Booking/GetBookings");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
                return new List<BookingDto>();
            }
        }
    }
}
