using KarpaticaTravelAPI.Models.CountryModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KarpaticaTravelAPI.Models.Requests.Country
{
    public class UpdateCountryRequest
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }

        [FromBody]
        public CountryUpdateDTO CountryUpdateDTO { get; set; }

    }
}

