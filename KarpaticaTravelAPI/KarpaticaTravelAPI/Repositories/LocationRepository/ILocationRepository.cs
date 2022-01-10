using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KarpaticaTravelAPI.Models;

namespace KarpaticaTravelAPI.Repositories.LocationRepository
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetLocations();
        Task<bool> UpdateLocation(Guid id, Location location);
        Task<Location> CreateLocation(Location location);
        Task<bool> DeleteLocation(Guid id);
        Task<Location> GetLocation(Guid id);
        Task<IEnumerable<Location>> GetLocationsByActivity(Guid activityId);
        Task<IEnumerable<Location>> GetLocationsByCountryAndCity(Guid countryId, Guid cityId);
        Task<IEnumerable<Location>> GetLocationsByCity(Guid cityId);
    }
}
