using WorldTour.Common.Mappings;
using WorldTour.Models;

namespace WorldTour.Dtos;

public class TourListDto : IMapFrom<TourList>
{
    public IList<TourPackageDto> Items { get; set; } = new List<TourPackageDto>();
    public int Id { get; set; }
    public string City { get; set; }
    public string About { get; set; }
}