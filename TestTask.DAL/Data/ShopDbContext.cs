using Microsoft.EntityFrameworkCore;
using TestTask.DAL.Entities;

namespace TestTask.DAL.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        #region DbSets

        DbSet<Client> Clients { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<CartItem> CartItems { get; set; }
        DbSet<Sale> Sales { get; set; }

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Sales)
                .UsingEntity<CartItem>();
        }
    }
}
