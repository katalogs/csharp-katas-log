namespace SupermarketReceipt.Domain.Offer
{
    internal class TenPercentDiscountOffer : Offer
    {
        private readonly double percent = 10;

        public TenPercentDiscountOffer(Product product)
            : base(product) { }

        public override Discount CreateDiscount(int quantityAsInt, double quantity, double unitPrice)
            => new (this._product, this.percent + "% off", -quantity * unitPrice * this.percent / 100.0);

        protected override int GetNbOfProductNecessaryForOffer() => 1;
    }
}
