namespace SupermarketReceipt.Domain.Offer;

public abstract class XForAmountOffer : Offer
{
    private readonly double amount;

    protected XForAmountOffer(Product product, double amount) : base(product)
    {
        this.amount = amount;
    }

    protected override Discount CreateDiscount(double quantity, double unitPrice)
    {
        var quantityAsInt = (int)quantity;
        var nbOfPacks = quantityAsInt / GetNbOfProductNecessaryForOffer();
        var discountTotal = unitPrice * quantity - (this.amount * nbOfPacks + quantityAsInt % GetNbOfProductNecessaryForOffer() * unitPrice);
        return new Discount(this._product, GetNbOfProductNecessaryForOffer() + " for " + this.amount, -discountTotal);
    }
}

public class FiveForAmountOffer : XForAmountOffer
{
    public FiveForAmountOffer(Product product, double amount) : base(product, amount)
    {
    }

    protected override int GetNbOfProductNecessaryForOffer() => 5;
}

public class TwoForAmountOffer : XForAmountOffer
{
    public TwoForAmountOffer(Product product, double amount) : base(product, amount)
    {
    }

    protected override int GetNbOfProductNecessaryForOffer() => 2;
}
