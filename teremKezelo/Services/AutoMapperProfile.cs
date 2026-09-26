using AutoMapper;
using teremKezelo.DTOS.LocationDtos;
using teremKezelo.DTOS.ReservationDtos;
using teremKezelo.DTOS.ResourceCategoryDtos;
using teremKezelo.DTOS.ResourceDtos;
using teremKezelo.DTOS.UserDtos;
using teremKezelo.Entities;

namespace teremKezelo.Services
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ResourceCreateDto, Resource>().ReverseMap();
            CreateMap<LocationCreateDto, Location>().ReverseMap();
            CreateMap<Resource, ResourceGetDto>().ReverseMap();
            CreateMap<ResourceCategoryCreateDto, ResourceCategory>().ReverseMap();
            CreateMap<ReservationCreateDto, Reservation>().ReverseMap();
            CreateMap<UserCreateDto, ApplicationUser>().ReverseMap();
        }
    }
}
