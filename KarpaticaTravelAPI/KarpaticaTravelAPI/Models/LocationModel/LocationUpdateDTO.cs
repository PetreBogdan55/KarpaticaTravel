using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Models.LocationModel
{
    public class LocationUpdateDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double DistanceFromCenter { get; set; }
        public double PricePerDay { get; set; }
        public bool IsAvailable { get; set; }
    }
}
