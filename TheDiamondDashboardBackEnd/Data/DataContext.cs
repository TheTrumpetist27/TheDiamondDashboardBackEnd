global using Microsoft.EntityFrameworkCore;

namespace TheDiamondDashboardBackEnd.Data
{
    public class DataContext : DbContext
    {
        static readonly string connectionString = "server=localhost;port=3306;database=thediamonddashboarddb;user=diamond;password=dashboard";
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Manager> manager { get; set; }
    }
}
