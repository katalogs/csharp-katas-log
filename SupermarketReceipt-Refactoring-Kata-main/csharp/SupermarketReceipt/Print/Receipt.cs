using System.Collections.Generic;
using SupermarketReceipt.ComputeOffer;
using SupermarketReceipt.Products;

namespace SupermarketReceipt.Print;

public class Receipt
{
    private readonly List<Discount> _discounts = new List<Discount>();
    private readonly List<ReceiptItem> _items = new List<ReceiptItem>();

    public double GetTotalPrice()
    {
        var total = 0.0;
        foreach (var item in _items) total += item.TotalPrice;
        foreach (var discount in _discounts) total += discount.DiscountAmount;
        return total;
    }

    public void AddProduct(Product p, double quantity, double price, double totalPrice)
    {
        _items.Add(new ReceiptItem(p, quantity, price, totalPrice));
    }

    public List<ReceiptItem> GetItems()
    {
        return new List<ReceiptItem>(_items);
    }

    public void AddDiscount(Discount discount)
    {
        _discounts.Add(discount);
    }

    public List<Discount> GetDiscounts()
    {
        return _discounts;
    }
}
