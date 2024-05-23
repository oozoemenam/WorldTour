using Microsoft.EntityFrameworkCore;
using WorldTour.Data.Models;

namespace WorldTour.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { } 

        public DbSet<TourList> TourList { get; set; }

        public DbSet<TourPackage> TourPackages { get; set; }    
    }
}
