using System.Globalization;

namespace SupermarketReceipt.ComputeOffer
{
    public enum SpecialOfferType
    {
        ThreeForTwo,
        TenPercentDiscount,
        TwoForAmount,
        FiveForAmount
    }

    public class Offer
    {
        private static readonly CultureInfo Culture = CultureInfo.CreateSpecificCulture("en-GB");

        private Product _product;

        public Offer(SpecialOfferType offerType, Product product, double argument)
        {
            OfferType = offerType;
            Argument = argument;
            _product = product;
        }

        public SpecialOfferType OfferType { get; }
        public double Argument { get; }

        public bool IsApplicable(int quantityAsInt)
        {
            var nbOfProductNecessaryForOffer = this.OfferType switch
            {
                SpecialOfferType.ThreeForTwo => 3,
                SpecialOfferType.TwoForAmount => 2,
                SpecialOfferType.FiveForAmount => 5,
                _ => 1
            };

            return quantityAsInt >= nbOfProductNecessaryForOffer;
        }

        public Discount CreateDiscount(double quantity, double unitPrice)
        {
            Discount discount = null;
            var quantityAsInt = (int)quantity;

            var nbOfProductNecessaryForOffer = OfferType switch
            {
                SpecialOfferType.ThreeForTwo => 3,
                SpecialOfferType.TwoForAmount => 2,
                SpecialOfferType.FiveForAmount => 5,
                _ => 1
            };

            if (IsApplicable(quantityAsInt))
            {
                int nbOfPacks = quantityAsInt / nbOfProductNecessaryForOffer;
                switch (OfferType)
                {
                    case SpecialOfferType.ThreeForTwo:
                        {
                            var discountAmount = quantity * unitPrice - (nbOfPacks * 2 * unitPrice + quantityAsInt % 3 * unitPrice);
                            discount = new Discount(_product, "3 for 2", -discountAmount);

                            break;
                        }
                    case SpecialOfferType.TenPercentDiscount:
                        discount = new Discount(_product,
                            Argument + "% off",
                            -quantity * unitPrice * Argument / 100.0);

                        break;
                    case SpecialOfferType.TwoForAmount:
                        {
                            var total = Argument * nbOfPacks + quantityAsInt % 2 * unitPrice;
                            var discountN = unitPrice * quantity - total;
                            discount = new Discount(_product, "2 for " + Argument.ToString(Culture), -discountN);

                            break;
                        }
                    case SpecialOfferType.FiveForAmount:
                        {
                            var discountTotal = unitPrice * quantity -
                                                (Argument * nbOfPacks + quantityAsInt % 5 * unitPrice);
                            discount = new Discount(_product,
                                nbOfProductNecessaryForOffer + " for " + Argument.ToString(Culture),
                                -discountTotal);

                            break;
                        }
                }
            }

            return discount;
        }
    }
}
