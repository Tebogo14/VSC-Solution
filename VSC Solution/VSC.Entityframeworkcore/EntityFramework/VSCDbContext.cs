using Microsoft.EntityFrameworkCore;
using VSC.Entityframeworkcore.Models;

namespace VSC.Entityframeworkcore.EntityFramework
{
    public class VSCDbContext : DbContext
    {

        public DbSet<ContactPerson> ContactPeople { get; set; }
        public DbSet<Entity> Entities { get; set; }

        public VSCDbContext(DbContextOptions<VSCDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}