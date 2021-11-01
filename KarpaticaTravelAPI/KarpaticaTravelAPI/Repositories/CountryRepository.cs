
using KarpaticaTravelAPI.Models;
using KarpaticaTravelAPI.Models.CountryModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Repositories
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

        public async Task<bool> DeleteCountry(int id)
        {
            Country country = await _context.Country.FindAsync(id)
;

            if (country == null)
            {
                return false;
            }

            _context.Country.Remove(country);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Country> GetCountry(int id)
        {
            Country country = await _context.Country.FindAsync(id)
;

            return country;
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await _context.Country.ToListAsync();
        }

        public async Task<bool> UpdateCountry(int id, Country country)
        {
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