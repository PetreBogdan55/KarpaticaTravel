using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KarpaticaTravelAPI.Models.Requests.Booking
{
    public class GetBookingsRequest
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }
    }
}
