using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Models.CityModel
{
    public class CityUpdateDTO
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
