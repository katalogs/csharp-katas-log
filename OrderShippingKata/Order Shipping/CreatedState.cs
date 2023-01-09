using OrderShipping.Domain.Exception;

namespace Order_Shipping
{
    internal class CreatedState : IState
    {
        public IState Approve()
        {
            return new ApprovedState();
        }

        public IState Reject()
        {
            return new RejectedState();
        }

        public IState Ship()
        {
            throw new OrderCannotBeShippedException();
        }
    }
}
