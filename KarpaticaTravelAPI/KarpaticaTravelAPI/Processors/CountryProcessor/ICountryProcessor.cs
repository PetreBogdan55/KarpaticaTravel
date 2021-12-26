using KarpaticaTravelAPI.Models.CountryModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Processors.CountryProcessor
{
    public interface ICountryProcessor
    {
        Task<bool> CreateCountry(CountryDTO country);
        Task<bool> DeleteCountry(int countryId);
        Task<IEnumerable<CountryDTO>> GetCountries();
        Task<CountryDTO> GetCountry(int id);
        Task<bool> UpdateCountry(int id, CountryUpdateDTO countryToUpdate);
    }
}