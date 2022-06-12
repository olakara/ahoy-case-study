namespace Application.Hotels.Queries.GetHotelsWithPagination
{
    public class HotelListingViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float Rating { get; set; }
        public int ReviewCount { get; set; }
        public decimal PricePerNight { get; set; }
        public string PhotoUrl { get; set; }
    }
}