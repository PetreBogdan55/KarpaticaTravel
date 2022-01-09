using KarpaticaTravelAPI.Models.CountryModel;
using Microsoft.AspNetCore.Mvc;

namespace KarpaticaTravelAPI.Models.Requests.Country
{
    public class CreateCountryRequest
    {
        [FromBody]
        public CountryDTO CountryDTO { get; set; }

    }
}

