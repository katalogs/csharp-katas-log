namespace SupermarketReceipt.Domain.Offer;

public abstract class XForAmountOffer : Offer
{
    protected XForAmountOffer(SpecialOfferType offerType, Product product, double argument) : base(offerType, product, argument) { }


    public override Discount CreateDiscount(int quantityAsInt, double quantity, double unitPrice)
    {
        var nbOfPacks = quantityAsInt / GetNbOfProductNecessaryForOffer();
        var discountTotal = unitPrice * quantity - (this._argument * nbOfPacks + quantityAsInt % GetNbOfProductNecessaryForOffer() * unitPrice);
        return new Discount(this._product, GetNbOfProductNecessaryForOffer() + " for " + this._argument, -discountTotal);
    }
}

public class FiveForAmountOffer : XForAmountOffer
{
    public FiveForAmountOffer(Product product, double argument) : base(SpecialOfferType.FiveForAmount, product, argument)
    {
    }

    protected override int GetNbOfProductNecessaryForOffer() => 5;
}

public class TwoForAmountOffer : XForAmountOffer
{
    public TwoForAmountOffer(Product product, double argument) : base(SpecialOfferType.TwoForAmount, product, argument)
    {
    }

    protected override int GetNbOfProductNecessaryForOffer() => 2;
}
