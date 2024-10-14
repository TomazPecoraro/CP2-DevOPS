using Microsoft.EntityFrameworkCore;
using Sprint3.Models.Mappings;
using Sprint3.Models.Models;

namespace Sprint3.Database
{
    public class FIAPDBContext(DbContextOptions<FIAPDBContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}

