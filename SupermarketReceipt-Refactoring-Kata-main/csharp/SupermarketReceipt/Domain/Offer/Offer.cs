using System;

namespace SupermarketReceipt.Domain.Offer
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
        protected Product _product;

        public Offer(SpecialOfferType offerType, Product product, double argument)
        {
            this._offerType = offerType;
            this._argument = argument;
            _product = product;
        }

        private SpecialOfferType _offerType { get; }
        protected double _argument { get; }

        public bool IsApplicable(int quantityAsInt)
        {
            var nbOfProductNecessaryForOffer = GetNbOfProductNecessaryForOffer();

            return quantityAsInt >= nbOfProductNecessaryForOffer;
        }

        protected virtual int GetNbOfProductNecessaryForOffer()
        {
            var nbOfProductNecessaryForOffer = this._offerType switch
            {
                SpecialOfferType.TwoForAmount => 2,
                SpecialOfferType.FiveForAmount => 5
            };
            return nbOfProductNecessaryForOffer;
        }

        public virtual Discount CreateDiscount(int quantityAsInt, double quantity, double unitPrice)
        {
            var ofProductNecessaryForOffer = this.GetNbOfProductNecessaryForOffer();
            var nbOfPacks = quantityAsInt / ofProductNecessaryForOffer;
            switch (this._offerType)
            {
                case SpecialOfferType.FiveForAmount or SpecialOfferType.TwoForAmount:
                    {
                        var discountTotal = unitPrice * quantity - (this._argument * nbOfPacks + quantityAsInt % GetNbOfProductNecessaryForOffer() * unitPrice);
                        return new Discount(this._product, ofProductNecessaryForOffer + " for " + this._argument, -discountTotal);
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
