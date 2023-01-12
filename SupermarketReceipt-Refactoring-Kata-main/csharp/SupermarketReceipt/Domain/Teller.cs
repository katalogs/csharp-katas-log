using SupermarketReceipt.Domain.Offer;
using System;
using System.Collections.Generic;

namespace SupermarketReceipt.Domain
{
    public class Teller
    {
        private readonly ISupermarketCatalog _catalog;
        private readonly Dictionary<Product, Offer.Offer> _offers = new Dictionary<Product, Offer.Offer>();

        public Teller(ISupermarketCatalog catalog)
        {
            _catalog = catalog;
        }

        public void AddSpecialOffer(SpecialOfferType offerType, Product product, double argument)
        {
            _offers[product] = offerType switch
            {
                SpecialOfferType.ThreeForTwo => new ThreeForTwoOffer(product, argument),
                SpecialOfferType.TenPercentDiscount => new TenPercentDiscountOffer(product, argument),
                SpecialOfferType.FiveForAmount => new FiveForAmountOffer(product, argument),
                SpecialOfferType.TwoForAmount => new TwoForAmountOffer(product, argument),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public Receipt ChecksOutArticlesFrom(ShoppingCart theCart)
        {
            var receipt = new Receipt();
            var productQuantities = theCart.GetItems();
            foreach (var pq in productQuantities)
            {
                var p = pq.Product;
                var quantity = pq.Quantity;
                var unitPrice = _catalog.GetUnitPrice(p);
                var price = quantity * unitPrice;
                receipt.AddProduct(p, quantity, unitPrice, price);
            }

            theCart.HandleOffers(receipt, _offers, _catalog);

            return receipt;
        }
    }

}
