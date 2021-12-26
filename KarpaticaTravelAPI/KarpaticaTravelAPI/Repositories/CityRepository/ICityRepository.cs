using KarpaticaTravelAPI.Models.CityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Repositories.CityRepository
{
    public interface ICityRepository
    {
        Task<bool> CreateCity(City city);
        Task<bool> DeleteCity(Guid id);
        Task<bool> UpdateCity(Guid id, City city);
        Task<City> GetCity(Guid id);
        Task<IEnumerable<City>> GetCities();

    }
}
