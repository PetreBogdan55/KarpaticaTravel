using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KarpaticaTravelAPI.Models.Requests.Location
{
    public class GetLocationsByActivityRequest
    {
        [FromRoute(Name = "activityId")]
        public Guid ActivityId { get; set; }
    }
}
