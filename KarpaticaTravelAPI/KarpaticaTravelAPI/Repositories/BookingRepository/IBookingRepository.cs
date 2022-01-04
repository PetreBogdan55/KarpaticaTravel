using KarpaticaTravelAPI.Models.BookingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Repositories.BookingRepository
{
    public interface IBookingRepository
    {
        Task<bool> CreateBooking(Booking booking);
        Task<bool> UpdateBooking(Guid id, Booking booking);
        Task<bool> DeleteBooking(Guid id);
        Task<Booking> GetBooking(Guid id);
        Task<IEnumerable<Booking>> GetBookings();
    }
}