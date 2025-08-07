using AutoMapper;
using Real_EstateCleanLayeredArchitecture.DTOs;
using Real_EstateCleanLayeredArchitecture.Models;

namespace Real_EstateCleanLayeredArchitecture.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Property, PropertyDto>().ReverseMap();
            CreateMap<CreatePropertyDto, Property>();
        }
    }
}
