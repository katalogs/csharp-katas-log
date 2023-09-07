using OrderShipping.Repository;
using OrderShipping.UseCase.Requests;

namespace OrderShipping.UseCase
{
    public class OrderApprovalUseCase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderApprovalUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Run(OrderApprovalRequest request)
        {
            var order = _orderRepository.GetById(request.OrderId);

            if (request.Approved)
                order.Approved();
            else
                order.Rejected();

            _orderRepository.Save(order);
        }
    }
}
