﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KarpaticaTravelAPI.Models
{
    public partial class Activity
    {
        public Activity()
        {
            Location = new HashSet<Location>();
        }

        public int ActivityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Location> Location { get; set; }
    }
}