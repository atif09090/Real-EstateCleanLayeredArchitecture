using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Real_EstateCleanLayeredArchitecture.Models
{
    public class Favorite
    {
        [Key, Column(Order = 0)]
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public User User { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Property")]
        public Guid PropertyId { get; set; }

        public Property Property { get; set; }
    }
}
