using Microsoft.EntityFrameworkCore;
using Real_EstateCleanLayeredArchitecture.Models;

namespace Real_EstateCleanLayeredArchitecture.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Property> Properties => Set<Property>();
        public DbSet<Favorite> Favorites => Set<Favorite>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorite>()
                .HasKey(f => new { f.UserId, f.PropertyId });
        }
    }
}
