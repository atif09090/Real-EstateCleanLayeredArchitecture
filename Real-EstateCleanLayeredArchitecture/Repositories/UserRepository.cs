using Microsoft.EntityFrameworkCore;
using Real_EstateCleanLayeredArchitecture.Data;
using Real_EstateCleanLayeredArchitecture.Models;
using Real_EstateCleanLayeredArchitecture.Repositories.Interfaces;

namespace Real_EstateCleanLayeredArchitecture.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) => _context = context;

        public async Task<User?> GetByEmailAsync(string email) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetByIdAsync(Guid id) =>
            await _context.Users.FindAsync(id);
    }
}
