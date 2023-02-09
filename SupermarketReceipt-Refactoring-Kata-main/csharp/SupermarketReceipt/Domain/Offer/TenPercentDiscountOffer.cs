﻿namespace SupermarketReceipt.Domain.Offer
{
    public class TenPercentDiscountOffer : Offer
    {
        private readonly double percent = 10;

        public TenPercentDiscountOffer(Product product)
            : base(product) { }

        protected override Discount CreateDiscount(double quantity, double unitPrice)
            => new (this._product, this.percent + "% off", -quantity * unitPrice * this.percent / 100.0);

        protected override int GetNbOfProductNecessaryForOffer()
            => 1;
    }
}
