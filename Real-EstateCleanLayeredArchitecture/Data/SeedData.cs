using Real_EstateCleanLayeredArchitecture.Models;

namespace Real_EstateCleanLayeredArchitecture.Data
{
    public class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Properties.Any())
            {
                context.Properties.AddRange(new List<Property>
                {
                    new Property {
                        Title = "Cozy Apartment", Address = "Newtown", Price = 350000,
                        ListingType = "Sale", Bedrooms = 2, Bathrooms = 1, CarSpots = 1,
                        Description = "Lovely modern apartment.",
                        ImageUrls = new List<string> { "https://cdn.shopify.com/s/files/1/0728/7865/3735/files/Kitchen-Readymade.png?v=1685362903" }
                    },
                    new Property {
                        Title = "Family Home", Address = "Greenville", Price = 750000,
                        ListingType = "Sale", Bedrooms = 4, Bathrooms = 3, CarSpots = 2,
                        Description = "Spacious and comfortable.",
                        ImageUrls = new List<string> { "https://friendshome.pk/cdn/shop/files/Untitledproject_12_2e9a047c-9ef9-4b8c-bec5-48e413e2e5b6.jpg?v=1725015615&width=1000" }
                    }
                });

                context.SaveChanges();
            }
        }
    }
}
