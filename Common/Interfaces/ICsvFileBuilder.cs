using WorldTour.TourLists.Queries.ExportTours;

namespace WorldTour.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTourPackagesFile(IEnumerable<TourPackageRecord> records);
}