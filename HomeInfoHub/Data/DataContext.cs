using HomeInfoHub.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeInfoHub.Extensions
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Sensor> Sensors { get; set; }

        public DbSet<Log> Logs { get; set; }
    }
}
