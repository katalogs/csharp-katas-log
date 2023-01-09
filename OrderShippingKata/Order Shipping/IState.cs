namespace Order_Shipping
{
    internal interface IState
    {
        void Approve();
        void Ship();
        void Reject();
    }
}
