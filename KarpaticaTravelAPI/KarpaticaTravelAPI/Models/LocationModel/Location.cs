using KarpaticaTravelAPI.Models.ActivityModel;
using KarpaticaTravelAPI.Models.BookingModel;
using KarpaticaTravelAPI.Models.CityModel;
using KarpaticaTravelAPI.Models.ReviewModel;
using KarpaticaTravelAPI.Models.UserModel;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KarpaticaTravelAPI.Models
{
    public partial class Location
    {
        public Location()
        {
            Booking = new HashSet<Booking>();
            Review = new HashSet<Review>();
        }

        public int LocationId { get; set; }
        public int CityId { get; set; }
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double DistanceFromUser { get; set; }
        public double PricePerDay { get; set; }
        public bool IsAvailable { get; set; }
        public int OwnerId { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual City City { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<Review> Review { get; set; }
    }
}
