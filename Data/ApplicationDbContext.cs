using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;

namespace Restaurant.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Reservation>()
                   .HasOne(r => r.Table);
            base.OnModelCreating(builder);
        }
        public DbSet<Restaurant.Data.Table> Table { get; set; }
        public DbSet<Restaurant.Data.Reservation> Reservation { get; set; }
    }
}