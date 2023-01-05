using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketReceipt.Domain
{
    public class ThreeForTwoOffer : Offer
    {
        public ThreeForTwoOffer(Product product, double argument)
            : base(SpecialOfferType.ThreeForTwo, product, argument) { }

        public override Discount CreateDiscount(int quantityAsInt, double quantity, double unitPrice, Product p)
        {
            var discountAmount = quantity * unitPrice - ((quantityAsInt / GetNbOfProductNecessaryForOffer()) * 2 * unitPrice + quantityAsInt % 3 * unitPrice);
            return new Discount(p, "3 for 2", -discountAmount);
        }

        public override int GetNbOfProductNecessaryForOffer() => 3;
    }
}
