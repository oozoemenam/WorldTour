using Microsoft.EntityFrameworkCore;
using WorldTour.Models;

namespace WorldTour.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TourList> TourLists { get; set; }
    DbSet<TourPackage> TourPackages { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}