using AutoMapper;
using KarpaticaTravelAPI.Models.CityModel;
using KarpaticaTravelAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Processors.CityProcessor
{
    public class CityProcessor : ICityProcessor
    {

        private ICityRepository _cityRepository;
        private IMapper _mapper;

        public CityProcessor(ICityRepository repository, IMapper mapper)
        {
            _cityRepository = repository;
            _mapper = mapper;
        }

        public async Task<bool> CreateCity(CityDTO city)
        {
            try
            {
                City newCity = _mapper.Map<CityDTO, City>(city);
                await _cityRepository.CreateCity(newCity).ConfigureAwait(false);

                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public async Task<bool> DeleteCity(int cityId)
        {
            try
            {
                return await _cityRepository.DeleteCity(cityId).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public async Task<IEnumerable<CityDTO>> GetCities()
        {
            IEnumerable<City> resultList = await _cityRepository.GetCities().ConfigureAwait(false);
            return new List<CityDTO>(_mapper.Map<IEnumerable<CityDTO>>(resultList));
        }

        public async Task<CityDTO> GetCity(int id)
        {
            City result = await _cityRepository.GetCity(id).ConfigureAwait(false);
            return (_mapper.Map<City, CityDTO>(result));
        }

        public async Task<bool> UpdateCity(int id, CityUpdateDTO cityToUpdate)
        {
            try
            {
                City newCityObject = _mapper.Map<CityUpdateDTO, City>(cityToUpdate);
                newCityObject.Id = id;

                return await _cityRepository.UpdateCity(id, newCityObject).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }
    }
}
