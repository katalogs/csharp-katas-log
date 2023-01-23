using OrderShipping.Domain.Exception;

namespace Order_Shipping
{
    public class ShippedState : IState
    {
        public IState Approve()
        {
            throw new ShippedOrdersCannotBeChangedException();
        }

        public IState Reject()
        {
            throw new ShippedOrdersCannotBeChangedException();
        }

        public IState Ship()
        {
            throw new OrderCannotBeShippedTwiceException();
        }
    }
}
