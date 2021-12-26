using KarpaticaTravelAPI.Models;
using KarpaticaTravelAPI.Models.CountryModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Repositories.CountryRepository
{
    public interface ICountryRepository
    {
        Task<Country> CreateCountry(Country country);
        Task<bool> DeleteCountry(Guid id);
        Task<IEnumerable<Country>> GetCountries();
        Task<Country> GetCountry(Guid id);
        Task<bool> UpdateCountry(Guid id, Country country);
    }
}