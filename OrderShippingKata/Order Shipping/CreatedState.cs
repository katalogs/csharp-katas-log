using OrderShipping.Domain.Exception;

namespace Order_Shipping
{
    internal class CreatedState : IState
    {
        public void Approve()
        {
            // Passage à Approved
        }

        public void Reject()
        {
            // Passage à Rejected
        }

        public void Ship()
        {
            throw new OrderCannotBeShippedException();
        }
    }
}
