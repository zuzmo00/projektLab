using AutoMapper;
using teremKezelo.DTOS.LocationDtos;
using teremKezelo.DTOS.ResourceDtos;
using teremKezelo.Entities;

namespace teremKezelo.Services
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ResourceCreateDto, Resource>().ReverseMap();
            CreateMap<LocationCreateDto, Location>().ReverseMap();
        }
    }
}
