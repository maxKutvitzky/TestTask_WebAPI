
using TestTask.DAL.Entities.Base;

namespace TestTask.DAL.Entities
{
    public class Sale : BaseEntity
    {
        public DateTime SaleDate { get; set; }
        
        private double _saleSummary;
        public double SaleSummary
        {
            get
            {
                _saleSummary = 0;

                if (Cart == null || !Cart.Any())
                {
                    return _saleSummary;
                }

                foreach (var cartItem in Cart) 
                {
                    _saleSummary += cartItem.ProductCount * cartItem.Product.Price;
                }

                return _saleSummary;
            }
            set
            {
                _saleSummary = value;
            }
        }

        public List<CartItem> Cart { get; set; }

        public List<Product> Products { get; set; }

        public Client Client { get; set; }
    }
}
