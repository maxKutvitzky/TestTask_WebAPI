using Microsoft.EntityFrameworkCore;

namespace TestTask.DAL.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        #region DbSets


        #endregion
    }
}
