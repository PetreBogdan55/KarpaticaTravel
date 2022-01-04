using KarpaticaTravelAPI.Models;
using KarpaticaTravelAPI.Models.BookingModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Repositories.BookingRepository
{
    public class BookingRepository : IBookingRepository
    {
        private KarpaticaTravelContext _context;

        public BookingRepository(KarpaticaTravelContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> CreateBooking(Booking booking)
        {
            try
            {
                await _context.Booking.AddAsync(booking).ConfigureAwait(false);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                return true;
            }
            catch (DbException dbException)
            {
                Console.WriteLine(dbException.Message);
                return false;
            }
        }

        public async Task<bool> DeleteBooking(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

            try
            {
                var booking = await _context.Booking.FindAsync(id);

                if (booking is null)
                {
                    return false;
                }

                _context.Booking.Remove(booking);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                return true;
            }
            catch (DbException dbException)
            {
                Console.WriteLine(dbException.Message);
                return false;
            }
        }

        public async Task<IEnumerable<Booking>> GetBookings()
        {
            return await _context.Booking.ToListAsync().ConfigureAwait(false);
        }

        public async Task<Booking> GetBooking(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

            Booking booking = await _context.Booking.FindAsync(id).ConfigureAwait(false);
            return booking;
        }

        public async Task<bool> UpdateBooking(Guid id, Booking booking)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

            if (id != booking.Id)
            {
                return false;
            }

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (DbUpdateConcurrencyException dbException)
            {
                if (!_context.Booking.Any(e => e.Id == id))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine(dbException.Message);
                    throw;
                }
            }
        }

    }
}
