using Information.Entity;
using Microsoft.EntityFrameworkCore;

namespace Information.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Factor> Factors { get; set; }
        public DbSet<Passenger> passengers { get; set; }
        public DbSet<Trip> trips { get; set; }
    }
}
