using KarpaticaTravelAPI.Models.BookingModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Processors.BookingProcessor
{
    public interface IBookingProcessor
    {
        Task<bool> CreateBooking(BookingDTO booking);
        Task<bool> DeleteBooking(Guid id);
        Task<bool> UpdateBooking(Guid id, BookingUpdateDTO bookingToUpdate);
        Task<BookingDTO> GetBooking(Guid id);
        Task<IEnumerable<BookingDTO>> GetBookingsByUser(Guid id);
        Task<IEnumerable<BookingDTO>> GetBookings();
    }
}
