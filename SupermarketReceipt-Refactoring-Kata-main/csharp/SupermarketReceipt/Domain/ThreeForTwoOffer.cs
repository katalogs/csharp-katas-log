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
    }
}
