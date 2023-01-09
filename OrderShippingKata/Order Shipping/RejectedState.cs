using OrderShipping.Domain.Exception;

namespace Order_Shipping
{
    internal class RejectedState : IState
    {
        public void Approve()
        {
            throw new RejectedOrderCannotBeApprovedException();
        }

        public void Reject()
        {
        }

        public void Ship()
        {
            throw new OrderCannotBeShippedException();
        }
    }
}
