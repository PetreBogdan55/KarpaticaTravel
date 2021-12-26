using AutoMapper;
using FluentValidation;
using KarpaticaTravelAPI.Models.CountryModel;
using KarpaticaTravelAPI.Repositories.CountryRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarpaticaTravelAPI.Processors.CountryProcessor
{
    public class CountryProcessor : ICountryProcessor
    {

        private ICountryRepository _countryRepository;
        private IMapper _mapper;

        public CountryProcessor(ICountryRepository repository, IMapper mapper)
        {
            _countryRepository = repository;
            _mapper = mapper;
        }

        public async Task<bool> CreateCountry(CountryDTO country)
        {
            try
            {
                CountryDTOValidator rules = new CountryDTOValidator();
                await rules.ValidateAndThrowAsync(country).ConfigureAwait(false);

                Country newCountry = _mapper.Map<CountryDTO, Country>(country);

                if (country.Id == Guid.Empty)
                {
                    newCountry.Id = Guid.NewGuid();

                }

                await _countryRepository.CreateCountry(newCountry).ConfigureAwait(false);

                return true;
            }
            catch (ValidationException exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public async Task<bool> DeleteCountry(Guid countryId)
        {
            try
            {
                return await _countryRepository.DeleteCountry(countryId).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public async Task<IEnumerable<CountryDTO>> GetCountries()
        {
            IEnumerable<Country> resultList = await _countryRepository.GetCountries().ConfigureAwait(false);
            return new List<CountryDTO>(_mapper.Map<IEnumerable<CountryDTO>>(resultList));
        }

        public async Task<CountryDTO> GetCountry(Guid id)
        {
            Country result = await _countryRepository.GetCountry(id).ConfigureAwait(false);
            return (_mapper.Map<Country, CountryDTO>(result));
        }

        public async Task<bool> UpdateCountry(Guid id, CountryUpdateDTO countryToUpdate)
        {
            try
            {
                CountryUpdateDTOValidator rules = new CountryUpdateDTOValidator();
                await rules.ValidateAndThrowAsync(countryToUpdate).ConfigureAwait(false);

                Country newCountry = _mapper.Map<CountryUpdateDTO, Country>(countryToUpdate);
                newCountry.Id = id;

                return await _countryRepository.UpdateCountry(id, newCountry).ConfigureAwait(false);
            }
            catch (ValidationException exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }
    }
}
