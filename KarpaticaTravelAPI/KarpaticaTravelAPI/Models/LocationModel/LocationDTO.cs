using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Models.LocationModel
{
    public class LocationDTO
    {
        public string Photo { get; set; }
        public int Capcity { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double DistanceFromCenter { get; set; }
        public double PricePerDay { get; set; }
        public bool IsAvailable { get; set; }
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public Guid ActivityId { get; set; }
        public Guid OwnerId { get; set; }

    }
}
