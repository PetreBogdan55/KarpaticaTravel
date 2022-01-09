using KarpaticaTravelAPI.Models;
using KarpaticaTravelAPI.Models.CityModel;
using KarpaticaTravelAPI.Models.CountryModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Repositories.LocationRepository
{
    public class LocationRepository : ILocationRepository
    {
        public KarpaticaTravelContext _context;

        public LocationRepository(KarpaticaTravelContext context)
        {
            _context = context;
        }

        public async Task<Location> CreateLocation(Location location)
        {
            await _context.Location.AddAsync(location).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return location;
        }

        public async Task<bool> DeleteLocation(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

            var location = await _context.Location.FindAsync(id);

            if (location == null)
            {
                return false;
            }

            _context.Location.Remove(location);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Location> GetLocation(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

            Location location = await _context.Location.FindAsync(id);

            return location;
        }

        public async Task<IEnumerable<Location>> GetLocations()
        {
            return await _context.Location.ToListAsync();
        }

        public async Task<bool> UpdateLocation(Guid id, Location location)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

            if (id != location.Id)
            {
                return false;
            }

            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Location.Any(e => e.Id == id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<IEnumerable<Location>> GetLocationsByActivity(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

            return await _context.Location.Where((loc) => loc.ActivityId == id).ToListAsync();
        }

        public async Task<IEnumerable<Location>> GetLocationsByCountryAndCity(Guid countryId, Guid cityId)
        {
            if (countryId == Guid.Empty || cityId == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }
            City city = await _context.City.Where((city) => city.Id == cityId && city.CountryId == countryId).FirstOrDefaultAsync();

            return await _context.Location.Where((loc) => loc.CityId== city.Id).ToListAsync();
        }
    }
}
