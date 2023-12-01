global using Microsoft.EntityFrameworkCore;

namespace TheDiamondDashboardBackEnd.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Manager> manager { get; set; }
    }
}
