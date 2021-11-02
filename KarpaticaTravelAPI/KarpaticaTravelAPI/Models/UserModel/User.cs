using KarpaticaTravelAPI.Models.BookingModel;
using KarpaticaTravelAPI.Models.ReviewModel;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KarpaticaTravelAPI.Models.UserModel
{
    public partial class User
    {
        public User()
        {
            Booking = new HashSet<Booking>();
            Location = new HashSet<Location>();
            Review = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool IsOwner { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<Location> Location { get; set; }
        public virtual ICollection<Review> Review { get; set; }
    }
}
