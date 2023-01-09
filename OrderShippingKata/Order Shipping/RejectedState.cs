using OrderShipping.Domain.Exception;

namespace Order_Shipping
{
    public class RejectedState : IState
    {
        public IState Approve()
        {
            throw new RejectedOrderCannotBeApprovedException();
        }

        public IState Reject()
        {
            return this;
        }

        public IState Ship()
        {
            throw new OrderCannotBeShippedException();
        }
    }
}
