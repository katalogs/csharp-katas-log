using LanguageExt;

namespace SupermarketReceipt.Domain.Offer;

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

    protected bool IsApplicable(double quantityAsInt)
        => quantityAsInt >= GetNbOfProductNecessaryForOffer();

    protected abstract int GetNbOfProductNecessaryForOffer();

    protected abstract Discount CreateDiscount(double quantity, double unitPrice);

    public Option<Discount> CreateDiscountIfApplicable(double quantity, double unitPrice)
        => this.IsApplicable(quantity) 
            ? this.CreateDiscount(quantity, unitPrice) 
            : Option<Discount>.None;
}
