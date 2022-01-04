using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KarpaticaTravelAPI.Models.LocationModel;
using Microsoft.AspNetCore.Mvc;

namespace KarpaticaTravelAPI.Models.Requests.Location
{
    public class CreateLocationRequest
    {
        [FromBody]
        public LocationDTO LocationDTO { get; set; }
    }
}
