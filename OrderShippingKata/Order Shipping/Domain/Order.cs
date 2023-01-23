using Order_Shipping;

namespace OrderShipping.Domain
{
    public class Order
    {

        public decimal Total { get; private set; }
        public string Currency { get; set; }
        public IList<OrderItem> Items { get; set; }
        public decimal Tax { get; private set; }
        public IState State { get; set; }
        public int Id { get; set; }

        public Order()
        {
            State = new CreatedState();
            Items = new List<OrderItem>();
            Currency = "EUR";
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            Items.Add(orderItem);
            Total += orderItem.TaxedAmount;
            Tax += orderItem.Tax;
        }

        internal void Approve()
        {
            State = State.Approve();
        }

        internal void Ship()
        {
            State = State.Ship();
        }
        internal void CheckShippability()
        {
            State.Ship();
        }

        internal void Reject()
        {
            State = State.Reject();
        }
    }
}
