using OrderShipping.Domain.Exception;

namespace Order_Shipping
{
    internal class ShippedState : IState
    {
        public void Approve()
        {
            throw new ShippedOrdersCannotBeChangedException();
        }

        public void Reject()
        {
            throw new ShippedOrdersCannotBeChangedException();
        }

        public void Ship()
        {
            throw new OrderCannotBeShippedTwiceException();
        }
    }
}
