using System.Collections.Generic;
using SupermarketReceipt.ComputeOffer;
using SupermarketReceipt.Products;

namespace SupermarketReceipt.Repository
{
    public class FakeCatalog : ISupermarketCatalog
    {
        private readonly IDictionary<string, double> _prices = new Dictionary<string, double>();
        private readonly IDictionary<string, Product> _products = new Dictionary<string, Product>();

        public void AddProduct(Product product, double price)
        {
            _products.Add(product.Name, product);
            _prices.Add(product.Name, price);
        }

        public double GetUnitPrice(Product product)
        {
            return _prices[product.Name];
        }
    }
}
