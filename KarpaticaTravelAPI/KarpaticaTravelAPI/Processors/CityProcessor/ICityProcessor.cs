using KarpaticaTravelAPI.Models.CityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Processors.CityProcessor
{
    public interface ICityProcessor
    {
        Task<bool> UpdateCity(Guid id, CityUpdateDTO cityToUpdate);
        Task<bool> DeleteCity(Guid cityId);
        Task<bool> CreateCity(CityDTO city);

        Task<CityDTO> GetCity(Guid id);

        Task<IEnumerable<CityDTO>> GetCities();

    }
}
