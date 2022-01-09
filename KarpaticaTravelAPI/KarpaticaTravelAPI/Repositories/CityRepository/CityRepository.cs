using KarpaticaTravelAPI.Models;
using KarpaticaTravelAPI.Models.CityModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Repositories.CityRepository
{
    public class CityRepository : ICityRepository
    {
        private KarpaticaTravelContext _context;
        public CityRepository(KarpaticaTravelContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> CreateCity(City city)
        {
            try
            {
                await _context.City.AddAsync(city).ConfigureAwait(false);
                await _context.SaveChangesAsync().ConfigureAwait(false);

                return true;
            }
            catch (DbException exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }

        }

        public async Task<bool> DeleteCity(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

            try
            {
                var city = await _context.City.FindAsync(id);

                if (city == null)
                {
                    return false;
                }

                _context.City.Remove(city);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbException exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public async Task<IEnumerable<City>> GetCities()
        {
            return await _context.City.ToListAsync();
        }

        public async Task<City> GetCity(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

            City city = await _context.City.FindAsync(id);
            return city;
        }

        public async Task<bool> UpdateCity(Guid id, City city)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

            if (id != city.Id)
            {
                return false;
            }

            _context.Entry(city).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException dbException)
            {
                if (!_context.City.Any(e => e.Id == id))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine(dbException.Message);
                    throw;
                }
            }
        }
    }
}
