using System.Collections.Generic;

namespace SupermarketReceipt.Domain
{
    public class Product
    {
        public Product(string name, ProductUnit unit)
        {
            this.Name = name;
            this.Unit = unit;
        }

        public string Name { get; }
        public ProductUnit Unit { get; }

        public override bool Equals(object obj)
        {
            var product = obj as Product;
            return product != null &&
                   this.Name == product.Name &&
                   this.Unit == product.Unit;
        }

        public override int GetHashCode()
        {
            var hashCode = -1996304355;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.Name);
            hashCode = hashCode * -1521134295 + this.Unit.GetHashCode();
            return hashCode;
        }
    }

    public class ProductQuantity
    {
        public ProductQuantity(Product product, double weight)
        {
            this.Product = product;
            this.Quantity = weight;
        }

        public Product Product { get; }
        public double Quantity { get; }
    }

    public enum ProductUnit
    {
        Kilo,
        Each
    }
}
