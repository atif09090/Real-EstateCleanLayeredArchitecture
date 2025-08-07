using Microsoft.EntityFrameworkCore;
using Real_EstateCleanLayeredArchitecture.Data;
using Real_EstateCleanLayeredArchitecture.Models;
using Real_EstateCleanLayeredArchitecture.Repositories.Interfaces;

namespace Real_EstateCleanLayeredArchitecture.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly ApplicationDbContext _context;
        public FavoriteRepository(ApplicationDbContext context) => _context = context;

        public async Task AddAsync(Favorite favorite)
        {
            _context.Favorites.Add(favorite);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Favorite favorite)
        {
            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Favorite>> GetFavoritesByUserIdAsync(Guid userId) =>
            await _context.Favorites.Include(f => f.Property)
                                     .Where(f => f.UserId == userId).ToListAsync();

        public async Task<Favorite?> GetAsync(Guid userId, Guid propertyId) =>
            await _context.Favorites.FindAsync(userId, propertyId);
    }
}
