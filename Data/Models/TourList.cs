namespace WorldTour.Data.Models
{
    public class TourList
    {
        public int Id { get; set; }

        public IList<TourPackage> Tours { get; set; } = [];

        public string? City { get; set; }

        public string? Country { get; set; }

        public string? About { get; set; }
    }
}
