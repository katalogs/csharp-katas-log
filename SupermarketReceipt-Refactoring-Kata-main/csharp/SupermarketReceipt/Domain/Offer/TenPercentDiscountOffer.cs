namespace SupermarketReceipt.Domain.Offer
{
    internal class TenPercentDiscountOffer : Offer
    {
        public TenPercentDiscountOffer(Product product, double argument)
            : base(SpecialOfferType.TenPercentDiscount, product, argument) { }

        public override Discount CreateDiscount(int quantityAsInt, double quantity, double unitPrice)
            => new (this._product, this._argument + "% off", -quantity * unitPrice * this._argument / 100.0);

        public override int GetNbOfProductNecessaryForOffer() => 1;
    }
}
