using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApi_PostGreSQLDemo.Database
{
    public class AppDbContext : IdentityDbContext<User>
    {

        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().Property(d => d.Initials).HasMaxLength(5);

            builder.HasDefaultSchema("Identity");
        }

        // add DbSet<T> properties here
    }
}
