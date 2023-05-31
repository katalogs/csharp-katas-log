using OrderShipping.UseCase;

namespace OrderShipping.Domain
{
    public class Order
    {
        public decimal Total { get; private set; }
        public string Currency { get; set; }
        public IList<OrderItem> Items { get; private set; }
        public decimal Tax { get; private set; }
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

        public void AddItems(OrderItem orderItem)
        {
            Items.Add(orderItem);
            Total += orderItem.TaxedAmount;
            Tax += orderItem.Tax;
        }

        internal void Approve()
        {
            ThrowWhenOrderAlreadyShipped();
            if (Status == OrderStatus.Rejected)
            {
                throw new RejectedOrderCannotBeApprovedException();
            }

            Status = OrderStatus.Approved;
        }

        internal void Reject()
        {
            ThrowWhenOrderAlreadyShipped();
            if (Status == OrderStatus.Approved)
            {
                throw new ApprovedOrderCannotBeRejectedException();
            }

            Status = OrderStatus.Rejected;
        }

        private void ThrowWhenOrderAlreadyShipped()
        {
            if (Status == OrderStatus.Shipped)
            {
                throw new ShippedOrdersCannotBeChangedException();
            }
        }

        internal void Ship()
        {
            if (Status == OrderStatus.Created || Status == OrderStatus.Rejected)
            {
                throw new OrderCannotBeShippedException();
            }

            if (Status == OrderStatus.Shipped)
            {
                throw new OrderCannotBeShippedTwiceException();
            }

            Status = OrderStatus.Shipped;
        }
    }
}
