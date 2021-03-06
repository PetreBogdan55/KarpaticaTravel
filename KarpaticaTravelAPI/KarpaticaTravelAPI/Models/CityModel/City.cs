using KarpaticaTravelAPI.Models.CountryModel;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KarpaticaTravelAPI.Models.CityModel
{
    public partial class City
    {
        public City()
        {
            Location = new HashSet<Location>();
        }

        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Location> Location { get; set; }
    }
}
