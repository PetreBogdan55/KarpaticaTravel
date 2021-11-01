using System;
using System.Collections.Generic;
using KarpaticaTravelAPI.Models.CityModel;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KarpaticaTravelAPI.Models.CountryModel
{
    public partial class Country
    {
        public Country()
        {
            City = new HashSet<City>();
        }

        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }

        public virtual ICollection<City> City { get; set; }
    }
}
