using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotesAPI.Controllers;
using KarpaticaTravelAPI.Models.LocationModel;
using KarpaticaTravelAPI.Processors.LocationProcessor;
using System.Net;
using FluentValidation;
using KarpaticaTravelAPI.Models.Requests.Location;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace KarpaticaTravelAPI.Controllers
{
    public class LocationsController : BaseController
    {
        private readonly ILocationProcessor _locationProcessor;

        public LocationsController(ILocationProcessor locationRepository)
        {
            _locationProcessor = locationRepository;
        }


        [ProducesResponseType(typeof(IEnumerable<LocationDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetLocationsAsync()
        {
            IEnumerable<LocationDTO> result = await _locationProcessor.GetLocations().ConfigureAwait(false);

            if (result == null)
            {
                return NotFound("No locations found.");
            }

            return Ok(result);
        }

        [ProducesResponseType(typeof(LocationDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationAsync(GetLocationRequest request)
        {
            try
            {
                GetLocationRequestValidator rules = new GetLocationRequestValidator();
                await rules.ValidateAndThrowAsync(request).ConfigureAwait(false);

                LocationDTO result = await _locationProcessor.GetLocation(request.Id).ConfigureAwait(false);

                if (result == null)
                {
                    return NotFound("No location found.");
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
        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocationAsync(UpdateLocationRequest request)
        {
            try
            {
                UpdateLocationRequestValidator rules = new UpdateLocationRequestValidator();
                await rules.ValidateAndThrowAsync(request).ConfigureAwait(false);

                if (!await _locationProcessor.UpdateLocation(request.Id, request.LocationUpdateDTO).ConfigureAwait(false))
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
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PostLocationAsync(CreateLocationRequest request)
        {
            try
            {
                CreateLocationRequestValidator rules = new CreateLocationRequestValidator();
                await rules.ValidateAndThrowAsync(request).ConfigureAwait(false);

                bool isCreated = await _locationProcessor.CreateLocation(request.LocationDTO).ConfigureAwait(false);

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
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocationAsync(DeleteLocationRequest request)
        {
            try
            {
                DeleteLocationRequestValidator rules = new DeleteLocationRequestValidator();
                await rules.ValidateAndThrowAsync(request).ConfigureAwait(false);

                bool result = await _locationProcessor.DeleteLocation(request.Id).ConfigureAwait(false);

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

        [ProducesResponseType(typeof(IEnumerable<LocationDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        [HttpGet("byActivity/{activityId}")]
        public async Task<IActionResult> GetLocationsByActivity(GetLocationsByActivityRequest request)
        {
            try
            {
                GetLocationsByActivityRequestValidator rules = new GetLocationsByActivityRequestValidator();
                await rules.ValidateAndThrowAsync(request).ConfigureAwait(false);

                IEnumerable<LocationDTO> resList = await _locationProcessor.GetLocationsByActivity(request.ActivityId).ConfigureAwait(false);

                if (resList is null || !resList.Any())
                {
                    return NotFound("No locations found for the specified activity");
                }

                return Ok(resList);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [ProducesResponseType(typeof(IEnumerable<LocationDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        [HttpGet("byCity/{cityId}")]
        public async Task<IActionResult> GetLocationsByCity(GetLocationsByCityRequest request)
        {
            try
            {
                GetLocationsByCityRequestValidator rules = new GetLocationsByCityRequestValidator();
                await rules.ValidateAndThrowAsync(request).ConfigureAwait(false);

                IEnumerable<LocationDTO> resList = await _locationProcessor.GetLocationsByCity(request.CityId).ConfigureAwait(false);

                if (resList is null || !resList.Any())
                {
                    return NotFound("No locations found for the specified city");
                }

                return Ok(resList);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [ProducesResponseType(typeof(IEnumerable<LocationDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        [HttpGet("byCountryAndCity/{countryId}/{cityId}")]
        public async Task<IActionResult> GetLocationsByCountryAndCity(GetLocationsByCountryAndCityRequest request)
        {
            try
            {
                GetLocationsByCountryAndCityRequestValidator rules = new GetLocationsByCountryAndCityRequestValidator();
                await rules.ValidateAndThrowAsync(request).ConfigureAwait(false);

                IEnumerable<LocationDTO> resList = await _locationProcessor.GetLocationsByCountryAndCity(request.CountryId, request.CityId).ConfigureAwait(false);

                if (resList is null || !resList.Any())
                {
                    return NotFound("No locations found for the specified country and city");
                }

                return Ok(resList);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
