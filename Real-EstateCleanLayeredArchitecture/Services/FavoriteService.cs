using AutoMapper;
using Real_EstateCleanLayeredArchitecture.DTOs;
using Real_EstateCleanLayeredArchitecture.Models;
using Real_EstateCleanLayeredArchitecture.Repositories.Interfaces;
using Real_EstateCleanLayeredArchitecture.Services.Interfaces;

namespace Real_EstateCleanLayeredArchitecture.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepo;
        private readonly IPropertyRepository _propertyRepo;
        private readonly IMapper _mapper;

        public FavoriteService(IFavoriteRepository favoriteRepo, IPropertyRepository propertyRepo, IMapper mapper)
        {
            _favoriteRepo = favoriteRepo;
            _propertyRepo = propertyRepo;
            _mapper = mapper;
        }

        public async Task<List<PropertyDto>> GetFavoritesAsync(Guid userId)
        {
            var favorites = await _favoriteRepo.GetFavoritesByUserIdAsync(userId);
            return _mapper.Map<List<PropertyDto>>(favorites.Select(f => f.Property));
        }

        public async Task<FavoriteResponseDto> ToggleFavoriteAsync(Guid userId, Guid propertyId)
        {
            var existing = await _favoriteRepo.GetAsync(userId, propertyId);
            if (existing != null)
            {
                await _favoriteRepo.RemoveAsync(existing);
                return new FavoriteResponseDto() { IsSuccess = true, Message = "Property removed from favorites." };
            }

            else 
            {
                await _favoriteRepo.AddAsync(new Favorite { UserId = userId, PropertyId = propertyId });
                return new FavoriteResponseDto() { IsSuccess = true, Message = "Property added to favorites." };
            }
        }
    }
}
