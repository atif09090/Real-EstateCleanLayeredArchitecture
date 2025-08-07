namespace Real_EstateCleanLayeredArchitecture.DTOs
{
    public class PropertySearchDto
    {
        public string? Title { get; set; }
        public string? City { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? MinBedrooms { get; set; }
        public int? MaxBedrooms { get; set; }
        public string? ListingType { get; set; }
    }

}