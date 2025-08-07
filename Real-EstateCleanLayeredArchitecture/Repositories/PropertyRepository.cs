using Real_EstateCleanLayeredArchitecture.Data;
using Real_EstateCleanLayeredArchitecture.Repositories.Interfaces;
using Real_EstateCleanLayeredArchitecture.Models;
using Microsoft.EntityFrameworkCore;
using Real_EstateCleanLayeredArchitecture.DTOs;
using AutoMapper;
namespace Real_EstateCleanLayeredArchitecture.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PropertyRepository(ApplicationDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        } 

        public async Task<List<Property>> GetAllAsync() => await _context.Properties.ToListAsync();

        public async Task<Property?> GetByIdAsync(Guid id) => await _context.Properties.FindAsync(id);

        public async Task<Property> AddAsync(Property property)
        {
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();
            return property;
        }

        public async Task<List<Property>> SearchPropertiesAsync(PropertySearchDto filters)
        {
            var query = _context.Properties.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filters.Title))
                query = query.Where(p => p.Title.Contains(filters.Title));

            if (!string.IsNullOrWhiteSpace(filters.City))
                query = query.Where(p => p.Address.Contains(filters.City));

            if (!string.IsNullOrEmpty(filters.ListingType))
                query = query.Where(p => p.ListingType.Contains(filters.ListingType));


            if (filters.MinPrice.HasValue && filters.MinPrice.Value != 0)
                query = query.Where(p => p.Price >= filters.MinPrice.Value);

            if (filters.MaxPrice.HasValue && filters.MaxPrice.Value != 0)
                query = query.Where(p => p.Price <= filters.MaxPrice.Value);

            if (filters.MinBedrooms.HasValue && filters.MinBedrooms.Value != 0)
                query = query.Where(p => p.Bedrooms >= filters.MinBedrooms.Value);

            if (filters.MaxBedrooms.HasValue && filters.MaxBedrooms.Value != 0)
                query = query.Where(p => p.Bedrooms <= filters.MaxBedrooms.Value);

            var properties = await query.ToListAsync();
            return properties;
        }

    }
}
