using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KarpaticaTravelAPI.Models;
using KarpaticaTravelAPI.Models.Dbcontext;
using NotesAPI.Controllers;
using KarpaticaTravelAPI.Repositories;

namespace KarpaticaTravelAPI.Controllers
{
    public class CountriesController : BaseController
    {
        private readonly ICountryRepository _countryRepository;

        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            IEnumerable<Country> result = await _countryRepository.GetCountries().ConfigureAwait(false);

            if (result == null)
            {
                return NotFound("No countries found.");
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            Country result = await _countryRepository.GetCountry(id).ConfigureAwait(false);

            if (result == null)
            {
                return NotFound("No country found.");
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            if (!await _countryRepository.UpdateCountry(id, country).ConfigureAwait(false))
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            Country countryCreated = await _countryRepository.CreateCountry(country).ConfigureAwait(false);

            if (countryCreated == null)
                return BadRequest(countryCreated);

            return Ok(countryCreated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Country>> DeleteCountry(int id)
        {
            bool result = await _countryRepository.DeleteCountry(id).ConfigureAwait(false);

            if (!result)
                return NotFound();

            return Ok(result);
        }
    }
}
