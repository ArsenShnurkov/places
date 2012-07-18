using System.Data.Entity;

namespace Places
{
    internal class Context : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }
    }
}