using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using hedomi.domain;

namespace hedomi.infrastructure.AppDBcontext
{
    public class AppDBContext : IdentityDbContext<User> 
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }


        //dbsets
        public DbSet<Article> Articles { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Article>()
                .Property(a => a.Price)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)");

            builder.Entity<OrderItem>()
                .Property(oi => oi.PriceAtPurchase)
                .HasColumnType("decimal(18,2)");
        }
    }
}
