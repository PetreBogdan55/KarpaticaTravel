using Microsoft.AspNetCore.Mvc;

namespace KarpaticaTravelAPI.Models.Requests.Country
{
    public class DeleteCountryRequest
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }

    }
}

