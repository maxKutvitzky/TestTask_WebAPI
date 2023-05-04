
using TestTask.DAL.Entities.Base;

namespace TestTask.DAL.Entities
{
    public class CartItem
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public Sale Sale { get; set; }
        public Product Product { get; set; }
        public int ProductCount { get; set; }
    }
}
