using AutoMapper;
using Real_EstateCleanLayeredArchitecture.DTOs;
using Real_EstateCleanLayeredArchitecture.Models;
using Real_EstateCleanLayeredArchitecture.Repositories.Interfaces;
using Real_EstateCleanLayeredArchitecture.Services.Interfaces;

namespace Real_EstateCleanLayeredArchitecture.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _repo;
        private readonly IMapper _mapper;

        public PropertyService(IPropertyRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<PropertyDto>> GetAllAsync()
        {
            var props = await _repo.GetAllAsync();
            return _mapper.Map<List<PropertyDto>>(props);
        }

        public async Task<PropertyDto?> GetByIdAsync(Guid id)
        {
            var prop = await _repo.GetByIdAsync(id);
            return prop == null ? null : _mapper.Map<PropertyDto>(prop);
        }

        public async Task<PropertyDto> CreateAsync(CreatePropertyDto dto)
        {
            var prop = _mapper.Map<Property>(dto);
            await _repo.AddAsync(prop);
            return _mapper.Map<PropertyDto>(prop);
        }

        public async Task<List<Property>> SearchPropertiesAsync(PropertySearchDto filters)
        {
           return await _repo.SearchPropertiesAsync(filters);
        }

    }

}
