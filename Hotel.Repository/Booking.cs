using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repository
{
    public class Booking : BaseRepository<BookingDto>
    {
        public void Create(BookingDto booking)
        {
            Execute("spCreateBooking", ParameterBuilder.BuildExclude(booking, "Id", "CustomerName", "RoomNumber", "RoomType"));
        }

        public void Delete(int id)
        {
            Execute("spDeleteBooking", new { Id = id });
        }

        public BookingDto GetById(int id)
        {
            return Get("spGetBookingById", new { Id = id });
        }

        public IEnumerable<BookingDto> GetBookings(int customerId, DateTime date)
        {
            return GetAll("spGetBookingsByCustomerOrDate", new { CustomerId = customerId, Date = date.ToLocalTime() });
        }

        public IEnumerable<BookingDto> GetBookings(int customerId, int month, int year)
        {
            return GetAll("spGetBookingsByCustomerOrYearAndMonth", new { CustomerId = customerId, Month = month, Year = year });
        }
    }
}
