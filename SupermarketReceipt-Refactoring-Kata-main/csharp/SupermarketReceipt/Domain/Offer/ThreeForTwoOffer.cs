namespace SupermarketReceipt.Domain.Offer
{
    public class ThreeForTwoOffer : Offer
    {
        public ThreeForTwoOffer(Product product, double argument)
            : base(SpecialOfferType.ThreeForTwo, product, argument) { }

        public override Discount CreateDiscount(int quantityAsInt, double quantity, double unitPrice)
        {
            var discountAmount = quantity * unitPrice - ((quantityAsInt / GetNbOfProductNecessaryForOffer()) * 2 * unitPrice + quantityAsInt % 3 * unitPrice);
            return new Discount(this._product, "3 for 2", -discountAmount);
        }

        protected override int GetNbOfProductNecessaryForOffer() => 3;
    }
}
