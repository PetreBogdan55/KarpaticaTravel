using KarpaticaTravelAPI.Models;
using KarpaticaTravelAPI.Models.CountryModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Repositories
{
    public interface ICountryRepository
    {
        Task<Country> CreateCountry(Country country);
        Task<bool> DeleteCountry(int id);
        Task<IEnumerable<Country>> GetCountries();
        Task<Country> GetCountry(int id);
        Task<bool> UpdateCountry(int id, Country country);
    }
}