using System;
using System.Collections.Generic;
using LanguageExt;

namespace SupermarketReceipt.Domain
{

    public class ShoppingCart
    {
        private readonly List<ProductQuantity> _items = new List<ProductQuantity>();

        private readonly Dictionary<Product, double> _productQuantities = new Dictionary<Product, double>();

        public List<ProductQuantity> GetItems()
        {
            return new List<ProductQuantity>(_items);
        }

        public void AddItem(Product product)
        {
            AddItemQuantity(product, 1.0);
        }

        public void AddItemQuantity(Product product, double quantity)
        {
            _items.Add(new ProductQuantity(product, quantity));
            if (_productQuantities.ContainsKey(product))
            {
                var newAmount = _productQuantities[product] + quantity;
                _productQuantities[product] = newAmount;
            }
            else
            {
                _productQuantities.Add(product, quantity);
            }
        }

        public void HandleOffers(Receipt receipt, Dictionary<Product, Offer.Offer> offers, ISupermarketCatalog catalog)
        {
            foreach (var p in _productQuantities.Keys)
            {
                if (offers.ContainsKey(p))
                {
                    var unitPrice = catalog.GetUnitPrice(p);
                    var discount = offers[p].CreateDiscountIfApplicable(_productQuantities[p], unitPrice);
                    discount.IfSome(receipt.AddDiscount);
                }
            }
        }

    }

}
