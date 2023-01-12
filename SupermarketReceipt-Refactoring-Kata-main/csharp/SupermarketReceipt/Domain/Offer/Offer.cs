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

        protected Offer(Product product)
            => _product = product;

        public bool IsApplicable(int quantityAsInt)
            => quantityAsInt >= GetNbOfProductNecessaryForOffer();

        protected abstract int GetNbOfProductNecessaryForOffer();

        public abstract Discount CreateDiscount(int quantityAsInt, double quantity, double unitPrice);
    }
}
