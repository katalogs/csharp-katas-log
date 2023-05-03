namespace OrderShipping.Domain
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TaxedAmount => Round(Product.PriceTTC * Quantity);
        public decimal Tax => Round(Product.Tax * Quantity);

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        private static decimal Round(decimal amount)
        {
            return decimal.Round(amount, 2, System.MidpointRounding.ToPositiveInfinity);
        }
    }
}
