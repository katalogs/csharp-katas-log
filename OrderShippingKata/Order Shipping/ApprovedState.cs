using OrderShipping.Domain.Exception;

namespace Order_Shipping
{
    public class ApprovedState : IState
    {
        public IState Approve()
        {
            return this;
        }

        public IState Reject()
        {
            throw new ApprovedOrderCannotBeRejectedException();
        }

        public IState Ship()
        {
            return new ShippedState();
        }
    }
}
