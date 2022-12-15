namespace SupermarketReceipt.Domain
{
    public class Discount
    {
        public Discount(Product product, string description, double discountAmount)
        {
            this.Product = product;
            this.Description = description;
            this.DiscountAmount = discountAmount;
        }

        public string Description { get; }
        public double DiscountAmount { get; }
        public Product Product { get; }
    }
}
