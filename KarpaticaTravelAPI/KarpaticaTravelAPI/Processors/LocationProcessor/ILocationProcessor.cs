using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KarpaticaTravelAPI.Models.LocationModel;

namespace KarpaticaTravelAPI.Processors.LocationProcessor
{
    public interface ILocationProcessor
    {
        Task<bool> CreateLocation(LocationDTO user);
        Task<bool> DeleteLocation(Guid locationId);
        Task<LocationDTO> GetLocation(Guid id);
        Task<IEnumerable<LocationDTO>> GetLocations();
        Task<bool> UpdateLocation(Guid id, LocationUpdateDTO locationToUpdate);
        Task<IEnumerable<LocationDTO>> GetLocationsByActivity(Guid activityId);
        Task<IEnumerable<LocationDTO>> GetLocationsByCountryAndCity(Guid countryId, Guid cityId);
        Task<IEnumerable<LocationDTO>> GetLocationsByCity(Guid cityId);

    }
}
