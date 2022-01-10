using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Models.Requests.Location
{
    public class GetLocationsByCityRequest
    {
        [FromRoute(Name = "cityId")]
        public Guid CityId { get; set; }
    }
}
