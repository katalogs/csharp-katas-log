using System;
using System.Collections.Generic;

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

        public void HandleOffers(Receipt receipt, Dictionary<Product, Offer> offers, ISupermarketCatalog catalog)
        {
            foreach (var p in _productQuantities.Keys)
            {
                var quantity = _productQuantities[p];
                var quantityAsInt = (int) quantity;
                if (offers.ContainsKey(p))
                {
                    var offer = offers[p];
                    var unitPrice = catalog.GetUnitPrice(p);

                    if (offer.IsApplicable(quantityAsInt))
                    {
                        receipt.AddDiscount(CreateDiscount(quantityAsInt, offer, quantity, unitPrice, p));
                    }
                }
            }
        }

        private static Discount CreateDiscount(int quantityAsInt, Offer offer, double quantity, double unitPrice, Product p)
        {
            var ofProductNecessaryForOffer = offer.GetNbOfProductNecessaryForOffer();
            int nbOfPacks = quantityAsInt / ofProductNecessaryForOffer;
            switch (offer.OfferType)
            {
                case SpecialOfferType.ThreeForTwo:
                {
                    var discountAmount = quantity * unitPrice - (nbOfPacks * 2 * unitPrice + quantityAsInt % 3 * unitPrice);
                    return  new Discount(p, "3 for 2", -discountAmount);
                }
                case SpecialOfferType.TenPercentDiscount:
                    return new Discount(p,
                        offer.Argument + "% off",
                        -quantity * unitPrice * offer.Argument / 100.0);
                    
                case SpecialOfferType.TwoForAmount:
                {
                    var total = offer.Argument * nbOfPacks + quantityAsInt % 2 * unitPrice;
                    var discountN = unitPrice * quantity - total;
                    return new Discount(p, "2 for " + offer.Argument, -discountN);

                    
                }
                case SpecialOfferType.FiveForAmount:
                {
                    var discountTotal = unitPrice * quantity -
                                        (offer.Argument * nbOfPacks + quantityAsInt % 5 * unitPrice);
                    return new Discount(p,
                        ofProductNecessaryForOffer + " for " + offer.Argument,
                        -discountTotal);
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

}
