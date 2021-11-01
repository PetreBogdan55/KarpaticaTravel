using AutoMapper;
using KarpaticaTravelAPI.Models.CityModel;

namespace KarpaticaTravelAPI.Models.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<City, CityDTO>();
            CreateMap<CityDTO, City>();
            CreateMap<CityUpdateDTO, City>();
        }
    }
}