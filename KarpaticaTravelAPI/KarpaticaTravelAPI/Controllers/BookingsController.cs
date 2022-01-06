using KarpaticaTravelAPI.Models.BookingModel;
using KarpaticaTravelAPI.Processors.BookingProcessor;
using Microsoft.AspNetCore.Mvc;
using NotesAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Controllers
{
    public class BookingsController : BaseController
    {
        private readonly IBookingProcessor _bookingProcessor;

        public BookingsController(IBookingProcessor processor)
        {
            _bookingProcessor = processor;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookingDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]

        public async Task<IActionResult> GetBookingsAsync()
        {
            IEnumerable<BookingDTO> res = await _bookingProcessor.GetBookings().ConfigureAwait(false);

            if (!res.Any())
            {
                return NotFound("There were no bookings in the database.");
            }

            return Ok(res);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BookingDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetBookingAsync(Guid id)
        {
            var booking = await _bookingProcessor.GetBooking(id).ConfigureAwait(false);

            if (booking is null)
            {
                return NotFound("Booking could not be found");
            }

            return Ok(booking);
        }
        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostBookingAsync([FromBody] BookingDTO bookingToPost)
        {
            bool res = await _bookingProcessor.CreateBooking(bookingToPost).ConfigureAwait(false);

            if (!res)
            {
                return NotFound("Booking could not be created");
            }

            return Ok("Booking created successfully");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PutBookingAsync(Guid id, [FromBody] BookingUpdateDTO updateBooking)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid parameters for booking update");
            }

            bool res = await _bookingProcessor.UpdateBooking(id, updateBooking).ConfigureAwait(false);

            if (!res)
            {
                return NotFound("Unable to find booking");
            }

            return Ok($"Booking with id {id} updated successfully");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteBookingAsync(Guid id)
        {
            bool res = await _bookingProcessor.DeleteBooking(id).ConfigureAwait(false);

            if (!res)
            {
                return NotFound("Unable to delete booking");
            }

            return Ok($"Booking with id {id} deleted successfully");
        }
    }
}