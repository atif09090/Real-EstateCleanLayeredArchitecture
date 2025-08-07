using Real_EstateCleanLayeredArchitecture.Models;

namespace Real_EstateCleanLayeredArchitecture.Repositories.Interfaces
{
    public interface IFavoriteRepository
    {
        Task AddAsync(Favorite favorite);
        Task RemoveAsync(Favorite favorite);
        Task<List<Favorite>> GetFavoritesByUserIdAsync(Guid userId);
        Task<Favorite?> GetAsync(Guid userId, Guid propertyId);
    }
}
