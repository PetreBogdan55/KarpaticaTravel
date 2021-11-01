using KarpaticaTravelAPI.Models.CityModel;
using KarpaticaTravelAPI.Processors.CityProcessor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Controllers
{
    public class CitiesController : BaseController
    {
        private readonly ICityProcessor _cityProcessor;

        public CitiesController(ICityProcessor cityProcessor)
        {
            _cityProcessor = cityProcessor;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCitiesAsync()
        {
            var cityList = await _cityProcessor.GetCities().ConfigureAwait(false);

            if (!cityList.Any())
            {
                return NotFound("There were no cities in the database");
            }

            return Ok(cityList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCityAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id must not be empty");
            }

            var city = await _cityProcessor.GetCity(id).ConfigureAwait(false);

            if (city == null)
            {
                return NotFound("City could not be found");
            }

            return Ok(city);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PostAsync([FromBody] CityDTO cityToPost)
        {
            if (string.IsNullOrWhiteSpace(cityToPost.Name) || cityToPost.Id == 0)
            {
                return BadRequest("Invalid parameters for city creation");
            }

            bool result = await _cityProcessor.CreateCity(cityToPost).ConfigureAwait(false);

            if (!result)
            {
                return NotFound("City could not be created.");
            }

            return Ok("City created successfully.");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CityUpdateDTO updateCity)
        {

            if (string.IsNullOrWhiteSpace(updateCity.Name))
            {
                return BadRequest("Invalid paramteres for city update.");
            }

            bool res = await _cityProcessor.UpdateCity(id, updateCity).ConfigureAwait(false);

            if (!res)
            {
                return NotFound("Unable to update city.");
            }

            return Ok($"City with id {id} updated successfully.");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id < 0)
            {
                return BadRequest("Invalid paramter for city deletion.");
            }

            bool res = await _cityProcessor.DeleteCity(id).ConfigureAwait(false);

            if (!res)
            {
                return NotFound("Unable to delete city.");
            }

            return Ok("City deleted successfully.");
        }

    }
}
