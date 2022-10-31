namespace OrderShipping.Domain
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }

        public decimal UnitaryTax => Round(this.Price / 100m * this.Category.TaxPercentage);

        public decimal UnitaryTaxedAmount => Round(this.Price + this.UnitaryTax);

        private static decimal Round(decimal amount)
        {
            return decimal.Round(amount, 2, System.MidpointRounding.ToPositiveInfinity);
        }
    }
}
