using Microsoft.EntityFrameworkCore;
using Musical_Instruments_ECommerce.Models;

namespace Musical_Instruments_ECommerce.DbConnection
{
    public class AppDbContext : DbContext
    {
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Instruments> Instruments { get; set; }
        public DbSet<InstrumentRating> InstrumentRatings { get; set; }
        public DbSet<OverallRating> OverallRatings { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-H0K0LN7;Database=MusicalInstrumentsECommerce;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
