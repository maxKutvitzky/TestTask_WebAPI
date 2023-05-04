
using TestTask.DAL.Entities.Base;

namespace TestTask.DAL.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string VendorCode { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }

        public List<CartItem> Cart { get; set; }

        public List<Sale> Sales { get; set; }
    }
}
