using KarpaticaTravelAPI.Models.CountryModel;
using Microsoft.AspNetCore.Mvc;

namespace KarpaticaTravelAPI.Models.Requests.Country
{
    public class UpdateCountryRequest
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }

        [FromBody]
        public CountryUpdateDTO CountryUpdateDTO { get; set; }

    }
}

