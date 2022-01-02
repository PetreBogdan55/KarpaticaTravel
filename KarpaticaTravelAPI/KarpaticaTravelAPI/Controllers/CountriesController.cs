using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotesAPI.Controllers;
using System.Net;
using KarpaticaTravelAPI.Processors.CountryProcessor;
using KarpaticaTravelAPI.Models.CountryModel;
using KarpaticaTravelAPI.Models.Requests.Country;
using FluentValidation;

namespace KarpaticaTravelAPI.Controllers
{
    public class CountriesController : BaseController
    {
        private readonly ICountryProcessor _countryProcessor;

        public CountriesController(ICountryProcessor userRepository)
        {
            _countryProcessor = userRepository;
        }


        [ProducesResponseType(typeof(IEnumerable<CountryDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetCountriesAsync()
        {
            IEnumerable<CountryDTO> result = await _countryProcessor.GetCountries().ConfigureAwait(false);

            if (result == null)
            {
                return NotFound("No countries found.");
            }

            return Ok(result);
        }

        [ProducesResponseType(typeof(CountryDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryAsync(GetCountryRequest request)
        {
            try
            {
                GetCountryRequestValidator rules = new GetCountryRequestValidator();
                await rules.ValidateAndThrowAsync(request).ConfigureAwait(false);

                CountryDTO result = await _countryProcessor.GetCountry(request.Id).ConfigureAwait(false);

                if (result == null)
                {
                    return NotFound("No country found.");
                }

                return Ok(result);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountryAsync(UpdateCountryRequest request)
        {
            try
            {
                UpdateCountryRequestValidator rules = new UpdateCountryRequestValidator();
                await rules.ValidateAndThrowAsync(request).ConfigureAwait(false);

                if (!await _countryProcessor.UpdateCountry(request.Id, request.CountryUpdateDTO).ConfigureAwait(false))
                {
                    return BadRequest();
                }

                return NoContent();
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> PostCountryAsync(CreateCountryRequest request)
        {
            try
            {
                CreateCountryRequestValidator rules = new CreateCountryRequestValidator();
                await rules.ValidateAndThrowAsync(request).ConfigureAwait(false);

                bool isCreated = await _countryProcessor.CreateCountry(request.CountryDTO).ConfigureAwait(false);

                if (!isCreated)
                {
                    return BadRequest(isCreated);
                }

                return Ok(isCreated);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountryAsync(DeleteCountryRequest request)
        {
            try
            {
                DeleteCountryRequestValidator rules = new DeleteCountryRequestValidator();
                await rules.ValidateAndThrowAsync(request).ConfigureAwait(false);

                bool result = await _countryProcessor.DeleteCountry(request.Id).ConfigureAwait(false);

                if (!result)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}