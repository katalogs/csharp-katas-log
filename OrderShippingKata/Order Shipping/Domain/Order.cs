using Ardalis.GuardClauses;

namespace OrderShipping.Domain
{
    public class Order
    {

        public decimal Total { get; private set; }
        public string Currency { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
        public decimal Tax { get; private set; }
        public OrderStatus Status { get; set; }
        public int Id { get; set; }

        public Order(List<OrderItem> items)
        {
            Status = OrderStatus.Created;
            Currency = "EUR";
            Items = Guard.Against.NullOrEmpty(items);
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            Items.Add(orderItem);
            Total += orderItem.TaxedAmount;
            Tax += orderItem.Tax;
        }
    }
}
