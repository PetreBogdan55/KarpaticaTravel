using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KarpaticaTravelAPI.Models.Requests.Location
{
    public class GetLocationsByCountryAndCityRequest
    {
        [FromRoute(Name = "countryId")]
        public Guid CountryId { get; set; }

        [FromRoute(Name = "cityId")]
        public Guid CityId { get; set; }
    }
}
