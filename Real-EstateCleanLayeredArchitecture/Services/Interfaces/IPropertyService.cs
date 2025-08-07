using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Real_EstateCleanLayeredArchitecture.DTOs;
using Real_EstateCleanLayeredArchitecture.Models;
namespace Real_EstateCleanLayeredArchitecture.Services.Interfaces
{
    public interface IPropertyService
    {
        Task<List<PropertyDto>> GetAllAsync();
        Task<PropertyDto?> GetByIdAsync(Guid id);
        Task<PropertyDto> CreateAsync(CreatePropertyDto dto);
        Task<List<Models.Property>> SearchPropertiesAsync(PropertySearchDto filters);
    }
}
