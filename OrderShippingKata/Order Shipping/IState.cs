namespace Order_Shipping
{
    public interface IState
    {
        IState Approve();
        IState Ship();
        IState Reject();
    }
}
