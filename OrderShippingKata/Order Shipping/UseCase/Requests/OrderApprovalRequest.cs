namespace OrderShipping.UseCase.Requests
{
    public class OrderApprovalRequest
    {
        public int OrderId { get; set; }
        public bool Approved { get; set; }
    }
}
