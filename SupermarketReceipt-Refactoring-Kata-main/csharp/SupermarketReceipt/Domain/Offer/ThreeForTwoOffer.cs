namespace SupermarketReceipt.Domain.Offer
{
    public class ThreeForTwoOffer : Offer
    {
        public ThreeForTwoOffer(Product product)
            : base(product) { }

        public override Discount CreateDiscount(double quantity, double unitPrice)
        {
            var quantityAsInt = (int)quantity;
            var discountAmount = quantity * unitPrice - ((quantityAsInt / GetNbOfProductNecessaryForOffer()) * 2 * unitPrice + quantityAsInt % 3 * unitPrice);
            return new Discount(this._product, "3 for 2", -discountAmount);
        }

        protected override int GetNbOfProductNecessaryForOffer() => 3;
    }
}
