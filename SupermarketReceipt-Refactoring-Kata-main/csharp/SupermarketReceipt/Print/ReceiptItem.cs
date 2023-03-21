using SupermarketReceipt.Products;

namespace SupermarketReceipt.Print;

public class ReceiptItem
{
    public Product Product { get; }
    public double Price { get; }
    public double TotalPrice { get; }
    public double Quantity { get; }

    public ReceiptItem(Product product, double quantity, double price, double totalPrice)
    {
        Product = product;
        Quantity = quantity;
        Price = price;
        TotalPrice = totalPrice;
    }
}
