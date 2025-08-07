using Real_EstateCleanLayeredArchitecture.Models;

namespace Real_EstateCleanLayeredArchitecture.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User> AddUserAsync(User user);
        Task<User?> GetByIdAsync(Guid id);
    }
}
