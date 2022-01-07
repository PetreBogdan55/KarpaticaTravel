using KarpaticaTravelAPI.Models.BookingModel;
using Microsoft.AspNetCore.Mvc;

namespace KarpaticaTravelAPI.Models.Requests.Booking
{
    public class CreateBookingRequest
    {
        [FromBody]
        public BookingDTO BookingsDTO { get; set; }
        public object BookingDTO { get; internal set; }
    }
}
