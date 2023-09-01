using OrderShipping.UseCase;

namespace OrderShipping.Domain
{
    public class Order
    {
        public decimal Total { get; set; }
        public string Currency { get; set; }
        public IList<OrderItem> Items { get; set; }
        public decimal Tax { get; set; }
        public OrderStatus Status { get; set; }
        public int Id { get; set; }

        public Order()
        {
            Status = OrderStatus.Created;
            Items = new List<OrderItem>();
            Currency = "EUR";
            Total = 0m;
            Tax = 0m;
        }

        public void Rejected()
        {
            CannotBeShipped();

            if (Status == OrderStatus.Approved)
                throw new ApprovedOrderCannotBeRejectedException();

            Status = OrderStatus.Rejected;
        }

        public void Approved()
        {
            CannotBeShipped();

            if (Status == OrderStatus.Rejected)
                throw new RejectedOrderCannotBeApprovedException();

            Status = OrderStatus.Approved;
        }

        private void CannotBeShipped()
        {
            if (Status == OrderStatus.Shipped)
                throw new ShippedOrdersCannotBeChangedException();
        }

        public void AddItem(Product product, int quantity)
        {
            OrderItem orderItem = new OrderItem
            {
                Product = product,
                Quantity = quantity
            };
            Items.Add(orderItem);
            Total += orderItem.TaxedAmount;
            Tax += orderItem.Tax;
        }
    }
}
