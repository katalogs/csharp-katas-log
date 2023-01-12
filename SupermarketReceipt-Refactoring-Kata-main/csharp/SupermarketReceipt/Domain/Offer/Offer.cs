namespace SupermarketReceipt.Domain.Offer
{
    public enum SpecialOfferType
    {
        ThreeForTwo,
        TenPercentDiscount,
        TwoForAmount,
        FiveForAmount
    }

    public abstract class Offer
    {
        protected Product _product;

        protected Offer(SpecialOfferType offerType, Product product, double argument)
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

        protected abstract int GetNbOfProductNecessaryForOffer();

        public abstract Discount CreateDiscount(int quantityAsInt, double quantity, double unitPrice);
    }
}
