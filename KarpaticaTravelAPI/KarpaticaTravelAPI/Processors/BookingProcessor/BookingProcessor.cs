using AutoMapper;
using KarpaticaTravelAPI.Models.BookingModel;
using KarpaticaTravelAPI.Repositories.BookingRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Processors.BookingProcessor
{
    public class BookingProcessor : IBookingProcessor
    {
        private IMapper _mapper;
        private IBookingRepository _bookingRepository;

        public BookingProcessor(IBookingRepository repository, IMapper mapper)
        {
            _bookingRepository = repository;
            _mapper = mapper;
        }

        public async Task<bool> CreateBooking(BookingDTO booking)
        {
            try
            {
                Booking newBooking = _mapper.Map<BookingDTO, Booking>(booking);

                if (booking.Id == Guid.Empty)
                {
                    newBooking.Id = Guid.NewGuid();
                }

                await _bookingRepository.CreateBooking(newBooking).ConfigureAwait(false);
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public async Task<bool> DeleteBooking(Guid id)
        {
            try
            {
                return await _bookingRepository.DeleteBooking(id).ConfigureAwait(false);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public async Task<IEnumerable<BookingDTO>> GetBookings()
        {
            IEnumerable<Booking> resList = await _bookingRepository.GetBookings().ConfigureAwait(false);
            return new List<BookingDTO>(_mapper.Map<IEnumerable<BookingDTO>>(resList));
        }

        public async Task<BookingDTO> GetBooking(Guid id)
        {
            Booking res = await _bookingRepository.GetBooking(id).ConfigureAwait(false);
            return (_mapper.Map<Booking, BookingDTO>(res));
        }

        public async Task<bool> UpdateBooking(Guid id, BookingUpdateDTO bookingToUpdate)
        {
            try
            {
                Booking newBooking = _mapper.Map<BookingUpdateDTO, Booking>(bookingToUpdate);
                newBooking.Id = bookingToUpdate.Id;

                return await _bookingRepository.UpdateBooking(id, newBooking).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

    }
}
