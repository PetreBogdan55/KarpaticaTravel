using Microsoft.AspNetCore.Mvc;

namespace KarpaticaTravelAPI.Models.Requests.Country
{
    public class GetCountryRequest
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }

    }
}

