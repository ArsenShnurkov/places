using System.Data.Entity;

namespace Places
{
    internal class Context : DbContext
    {
        public DbSet<Country> Countries { get; set; }
    }
}