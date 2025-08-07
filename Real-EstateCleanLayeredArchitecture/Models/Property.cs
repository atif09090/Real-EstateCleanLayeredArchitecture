using System.ComponentModel.DataAnnotations;

namespace Real_EstateCleanLayeredArchitecture.Models
{
    public class Property
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ListingType { get; set; } = string.Empty; // Rent or Sale

        [Required]
        public int Bedrooms { get; set; }

        [Required]
        public int Bathrooms { get; set; }

        [Required]
        public int CarSpots { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        public List<string> ImageUrls { get; set; } = new();

    }


}
