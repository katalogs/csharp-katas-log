using System;

namespace SupermarketReceipt.Domain
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
        private Product _product;

        public Offer(SpecialOfferType offerType, Product product, double argument)
        {
            this.OfferType = offerType;
            this.Argument = argument;
            _product = product;
        }

        public SpecialOfferType OfferType { get; }
        public double Argument { get; }

        public bool IsApplicable(int quantityAsInt)
        {
            var nbOfProductNecessaryForOffer = GetNbOfProductNecessaryForOffer();

            return quantityAsInt >= nbOfProductNecessaryForOffer;
        }

        public int GetNbOfProductNecessaryForOffer()
        {
            var nbOfProductNecessaryForOffer = this.OfferType switch
            {
                SpecialOfferType.ThreeForTwo => 3,
                SpecialOfferType.TwoForAmount => 2,
                SpecialOfferType.FiveForAmount => 5,
                _ => 1
            };
            return nbOfProductNecessaryForOffer;
        }

        public Discount CreateDiscount(int quantityAsInt, double quantity, double unitPrice, Product p)
        {
            var ofProductNecessaryForOffer = this.GetNbOfProductNecessaryForOffer();
            int nbOfPacks = quantityAsInt / ofProductNecessaryForOffer;
            switch (this.OfferType)
            {
                case SpecialOfferType.ThreeForTwo:
                    {
                        var discountAmount = quantity * unitPrice - (nbOfPacks * 2 * unitPrice + quantityAsInt % 3 * unitPrice);
                        return new Discount(p, "3 for 2", -discountAmount);
                    }
                case SpecialOfferType.TenPercentDiscount:
                    return new Discount(p,
                        this.Argument + "% off",
                        -quantity * unitPrice * this.Argument / 100.0);

                case SpecialOfferType.FiveForAmount or SpecialOfferType.TwoForAmount:
                    {
                        var discountTotal = unitPrice * quantity - (this.Argument * nbOfPacks + quantityAsInt % GetNbOfProductNecessaryForOffer() * unitPrice);
                        return new Discount(p, ofProductNecessaryForOffer + " for " + this.Argument, -discountTotal);
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
