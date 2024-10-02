namespace WorldTour.Models;

public class TourList
{
    public int Id { get; set; }
    public string? City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string? About { get; set; }
    public List<TourPackage>? Tours { get; set; }
}