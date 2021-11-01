using KarpaticaTravelAPI.Models.CityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Processors.CityProcessor
{
    public interface ICityProcessor
    {
        Task<bool> UpdateCity(int id, CityUpdateDTO cityToUpdate);
        Task<bool> DeleteCity(int cityId);
        Task<bool> CreateCity(CityDTO city);

        Task<CityDTO> GetCity(int id);

        Task<IEnumerable<CityDTO>> GetCities();

    }
}
