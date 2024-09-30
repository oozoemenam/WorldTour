using Microsoft.EntityFrameworkCore;
using WorldTour.Models;

namespace WorldTour.Data;

public class TourDbContext : DbContext
{
    public TourDbContext(DbContextOptions<TourDbContext> options) : base(options) {}

    public DbSet<TourList> TourLists => Set<TourList>();
    
    public DbSet<TourPackage> TourPackages => Set<TourPackage>();
}