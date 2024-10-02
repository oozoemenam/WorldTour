using WorldTour.Common.Mappings;
using WorldTour.Models;

namespace WorldTour.TourLists.Queries.ExportTours;

public class TourPackageRecord : IMapFrom<TourPackage>
{
    public string Name { get; set; }
    public string MapLocation { get; set; }
}