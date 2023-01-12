namespace SupermarketReceipt.Domain.Offer
{
    internal class TenPercentDiscountOffer : Offer
    {
        public TenPercentDiscountOffer(Product product, double argument)
            : base(SpecialOfferType.TenPercentDiscount, product, argument) { }

        public override Discount CreateDiscount(int quantityAsInt, double quantity, double unitPrice, Product p)
            => new (p, this.Argument + "% off", -quantity * unitPrice * this.Argument / 100.0);

        public override int GetNbOfProductNecessaryForOffer() => 1;
    }
}
