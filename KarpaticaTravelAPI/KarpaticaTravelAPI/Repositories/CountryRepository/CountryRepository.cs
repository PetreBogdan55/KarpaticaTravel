
using KarpaticaTravelAPI.Models;
using KarpaticaTravelAPI.Models.CountryModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Repositories.CountryRepository
{
    public class CountryRepository : ICountryRepository
    {
        public KarpaticaTravelContext _context;


        public CountryRepository(KarpaticaTravelContext context)
        {
            _context = context;
        }

        public async Task<Country> CreateCountry(Country country)
        {
            await _context.Country.AddAsync(country).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return country;
        }

        public async Task<bool> DeleteCountry(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

            Country country = await _context.Country.FindAsync(id);

            if (country == null)
            {
                return false;
            }

            _context.Country.Remove(country);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Country> GetCountry(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

            Country country = await _context.Country.FindAsync(id);

            return country;
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await _context.Country.ToListAsync();
        }

        public async Task<bool> UpdateCountry(Guid id, Country country)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id", "Id is null or empty.");
            }

            if (id != country.Id)
            {
                return false;
            }

            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Country.Any(e => e.Id == id))
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
    }
}