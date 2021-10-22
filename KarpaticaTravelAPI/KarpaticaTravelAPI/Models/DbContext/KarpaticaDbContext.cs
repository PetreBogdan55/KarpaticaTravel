
using Microsoft.EntityFrameworkCore;

namespace KarpaticaTravelAPI.Models.Dbcontext
{
    public class KarpaticaDbContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public DbSet<Country> Country { get; set; }

        public KarpaticaDbContext(DbContextOptions<KarpaticaDbContext> options) : base(options)
        {
        }
    }
}