
namespace TestTask.DAL.Entities
{
    public class CartItem
    {
        public Sale Sale { get; set; }
        public Product Product { get; set; }
        public int ProductCount { get; set; }
    }
}
