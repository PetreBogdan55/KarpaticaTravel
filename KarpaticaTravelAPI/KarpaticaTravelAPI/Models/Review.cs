using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KarpaticaTravelAPI.Models
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }

        public virtual Location Location { get; set; }
        public virtual User User { get; set; }
    }
}
