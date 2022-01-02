using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KarpaticaTravelAPI.Models.LocationModel;
using Microsoft.AspNetCore.Mvc;

namespace KarpaticaTravelAPI.Models.Requests.Location
{
    public class UpdateLocationRequest
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }

        [FromBody]
        public LocationUpdateDTO LocationUpdateDTO { get; set; }
    }
}
