using System.ComponentModel.DataAnnotations;

namespace Real_EstateCleanLayeredArchitecture.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public ICollection<Favorite> Favorites { get; set; }
    }
}
