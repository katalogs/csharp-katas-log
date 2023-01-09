namespace Order_Shipping
{
    public interface IState
    {
        void Approve();
        void Ship();
        void Reject();
    }
}
