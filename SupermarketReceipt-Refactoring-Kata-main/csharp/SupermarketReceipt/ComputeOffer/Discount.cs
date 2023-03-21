using SupermarketReceipt.Products;

namespace SupermarketReceipt.ComputeOffer
{
    public class Discount
    {
        public string Description { get; }
        public double DiscountAmount { get; }
        public Product Product { get; }

        public Discount(Product product, string description, double discountAmount)
        {
            Product = product;
            Description = description;
            DiscountAmount = discountAmount;
        }
    }
}
