using Microsoft.AspNetCore.Mvc;
using System;

namespace KarpaticaTravelAPI.Models.Requests.Country
{
    public class DeleteCountryRequest
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }

    }
}

