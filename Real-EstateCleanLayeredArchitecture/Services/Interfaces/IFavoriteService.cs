using Real_EstateCleanLayeredArchitecture.DTOs;

namespace Real_EstateCleanLayeredArchitecture.Services.Interfaces
{
    public interface IFavoriteService
    {
        Task<List<PropertyDto>> GetFavoritesAsync(Guid userId);
        Task<FavoriteResponseDto> ToggleFavoriteAsync(Guid userId, Guid propertyId);
    }
}
