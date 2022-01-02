using KarpaticaTravelAPI.Models.UserModel;
using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KarpaticaTravelAPI.Models.BookingModel
{
    public partial class Booking
    {
        public Guid UserId { get; set; }
        public Guid LocationId { get; set; }
        public Guid Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool IsCancellable { get; set; }
        public string Flag { get; set; }
        public virtual Location Location { get; set; }
        public virtual User User { get; set; }  
    }
}
