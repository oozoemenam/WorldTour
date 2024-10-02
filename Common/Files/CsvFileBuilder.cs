using System.Globalization;
using CsvHelper;
using WorldTour.Common.Interfaces;
using WorldTour.Models;
using WorldTour.TourLists.Queries.ExportTours;

namespace WorldTour.Common.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTourPackagesFile(IEnumerable<TourPackageRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}