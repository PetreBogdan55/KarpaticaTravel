using KarpaticaTravelAPI.Models.LocationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using KarpaticaTravelAPI.Infrastructure;
using KarpaticaTravelAPI.Models;
using KarpaticaTravelAPI.Models.UserModel;
using KarpaticaTravelAPI.Repositories.LocationRepository;
using KarpaticaTravelAPI.Repositories.UserRepository;

namespace KarpaticaTravelAPI.Processors.LocationProcessor
{
    public class LocationProcessor : ILocationProcessor
    {
        private ILocationRepository _locationRepository;
        private IMapper _mapper;

        public LocationProcessor(ILocationRepository repository, IMapper mapper)
        {
            _locationRepository = repository;
            _mapper = mapper;
        }
        public async Task<bool> CreateLocation(LocationDTO location)
        {
            try
            {
                LocationDTOValidator rules = new LocationDTOValidator();
                await rules.ValidateAndThrowAsync(location).ConfigureAwait(false);

                Location newLocation = _mapper.Map<LocationDTO, Location>(location);

                if (location.Id == Guid.Empty)
                {
                    newLocation.Id = Guid.NewGuid();

                }


                await _locationRepository.CreateLocation(newLocation).ConfigureAwait(false);

                return true;
            }
            catch (ValidationException validationException)
            {
                Console.WriteLine(validationException.Message);
                return false;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public async Task<bool> DeleteLocation(Guid locationId)
        {
            try
            {
                return await _locationRepository.DeleteLocation(locationId).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public async Task<LocationDTO> GetLocation(Guid id)
        {
            Location result = await _locationRepository.GetLocation(id).ConfigureAwait(false);
            return (_mapper.Map<Location, LocationDTO>(result));
        }

        public async Task<IEnumerable<LocationDTO>> GetLocations()
        {
            IEnumerable<Location> resultList = await _locationRepository.GetLocations().ConfigureAwait(false);
            return new List<LocationDTO>(_mapper.Map<IEnumerable<LocationDTO>>(resultList));
        }

        public async Task<bool> UpdateLocation(Guid id, LocationUpdateDTO locationToUpdate)
        {
            try
            {
                LocationUpdateDTOValidator rules = new LocationUpdateDTOValidator();
                await rules.ValidateAndThrowAsync(locationToUpdate).ConfigureAwait(false);

                Location newLocationObject = _mapper.Map<LocationUpdateDTO, Location>(locationToUpdate);
                newLocationObject.Id = id;

                return await _locationRepository.UpdateLocation(id, newLocationObject).ConfigureAwait(false);
            }
            catch (ValidationException validationException)
            {
                Console.WriteLine(validationException.Message);
                return false;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public async Task<IEnumerable<LocationDTO>> GetLocationsByActivity(Guid activityId)
        {
            IEnumerable<Location> locationsList = await _locationRepository.GetLocationsByActivity(activityId).ConfigureAwait(false);
            return new List<LocationDTO>(_mapper.Map<IEnumerable<LocationDTO>>(locationsList));
        }

        public async Task<IEnumerable<LocationDTO>> GetLocationsByCountryAndCity(Guid countryId, Guid cityId)
        {
            IEnumerable<Location> locationsList = await _locationRepository.GetLocationsByCountryAndCity(countryId, cityId).ConfigureAwait(false);
            return new List<LocationDTO>(_mapper.Map<IEnumerable<LocationDTO>>(locationsList));
        }
    }
}
