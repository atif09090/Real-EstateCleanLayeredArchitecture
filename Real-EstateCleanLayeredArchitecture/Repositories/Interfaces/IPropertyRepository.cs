using Real_EstateCleanLayeredArchitecture.DTOs;
using Real_EstateCleanLayeredArchitecture.Models;
namespace Real_EstateCleanLayeredArchitecture.Repositories.Interfaces
{
    public interface IPropertyRepository
    {
        Task<List<Property>> GetAllAsync();
        Task<Property?> GetByIdAsync(Guid id);
        Task<Property> AddAsync(Property property);
        Task<List<Property>> SearchPropertiesAsync(PropertySearchDto filters);
    }
}
