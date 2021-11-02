using AutoMapper;
using KarpaticaTravelAPI.Models.ActivityModel;
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

            CreateMap<Activity, ActivityDTO>();
            CreateMap<ActivityDTO, Activity>();
            CreateMap<ActivityUpdateDTO, Activity>();
        }
    }
}