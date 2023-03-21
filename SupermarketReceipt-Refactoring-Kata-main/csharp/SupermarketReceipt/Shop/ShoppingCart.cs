using System.Collections.Generic;
using System.Linq;
using SupermarketReceipt.ComputeOffer;
using SupermarketReceipt.Print;
using SupermarketReceipt.Products;

namespace SupermarketReceipt.Shop
{
    public class ShoppingCart
    {
        private readonly List<ShoppingCartItem> _items = new List<ShoppingCartItem>();

        //Fix for 500€
        private readonly List<ShoppingCartItem> _itemsAddHistory = new List<ShoppingCartItem>();

        public IReadOnlyCollection<ShoppingCartItem> GetItems() => _itemsAddHistory;

        public void AddItem(Product product)
        {
            AddItemQuantity(product, 1.0);
        }

        public void AddItemQuantity(Product product, double quantity)
        {
            _itemsAddHistory.Add(new ShoppingCartItem(product, quantity));
            if (_items.Any(_ => _.Product == product))
            {
                var itemToUpdate = _items.First(_ => _.Product == product);
                itemToUpdate.IncreaseQuantity(quantity);
            }
            else
            {
                _items.Add(new ShoppingCartItem(product, quantity));
            }
        }

        public void HandleOffers(Receipt receipt, Dictionary<Product, Offer> offers, ISupermarketCatalog catalog)
        {
            foreach (var item in _items)
            {                
                if (offers.ContainsKey(item.Product))
                {
                    var offer = offers[item.Product];
                    var unitPrice = catalog.GetUnitPrice(item.Product);
                    Discount discount = offer.CreateDiscount(item.Quantity, unitPrice);

                    if (discount != null) receipt.AddDiscount(discount);
                }
            }
        }
    }

}
