using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration.Conventions;
using TestTask.DAL.Entities;

namespace TestTask.DAL.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        #region DbSets

        DbSet<Client> Client { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<CartItem> CartItem { get; set; }
        DbSet<Sale> Sale { get; set; }

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
