using KarpaticaTravelAPI.Models.CityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Repositories
{
    public interface ICityRepository
    {
        Task<bool> CreateCity(City city);
        Task<bool> DeleteCity(int id);
        Task<bool> UpdateCity(int id, City city);
        Task<City> GetCity(int id);
        Task<IEnumerable<City>> GetCities();

    }
}
