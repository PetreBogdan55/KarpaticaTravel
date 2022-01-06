using AutoMapper;
using KarpaticaTravelAPI.Models.ActivityModel;
using KarpaticaTravelAPI.Models.CityModel;
using KarpaticaTravelAPI.Models.CountryModel;
using KarpaticaTravelAPI.Models.LocationModel;
using KarpaticaTravelAPI.Models.ReviewModel;
using KarpaticaTravelAPI.Models.UserModel;

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

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<UserUpdateDTO, User>();

            CreateMap<Country, CountryDTO>();
            CreateMap<CountryDTO, Country>();
            CreateMap<CountryUpdateDTO, Country>();

            CreateMap<Review, ReviewDTO>();
            CreateMap<ReviewDTO, Review>();
            CreateMap<ReviewUpdateDTO, Review>();

            CreateMap<Location, LocationDTO>();
            CreateMap<LocationDTO, Location>();
            CreateMap<LocationUpdateDTO, Location>();
        }
    }
}