using OrderShipping.Domain.Exception;

namespace Order_Shipping
{
    internal class ApprovedState : IState
    {
        public void Approve()
        {
        }

        public void Reject()
        {
            throw new RejectedOrderCannotBeApprovedException();
        }

        public void Ship()
        {
            // Passage à Shipped
        }
    }
}
