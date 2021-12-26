using KarpaticaTravelAPI.Models.CountryModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Processors.CountryProcessor
{
    public interface ICountryProcessor
    {
        Task<bool> CreateCountry(CountryDTO country);
        Task<bool> DeleteCountry(Guid countryId);
        Task<IEnumerable<CountryDTO>> GetCountries();
        Task<CountryDTO> GetCountry(Guid id);
        Task<bool> UpdateCountry(Guid id, CountryUpdateDTO countryToUpdate);
    }
}