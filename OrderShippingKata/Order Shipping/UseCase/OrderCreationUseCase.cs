using OrderShipping.Domain;
using OrderShipping.Repository;

namespace OrderShipping.UseCase
{
    public class OrderCreationUseCase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductCatalog _productCatalog;



        public OrderCreationUseCase(
             IOrderRepository orderRepository,
             IProductCatalog productCatalog)
        {
            _orderRepository = orderRepository;
            _productCatalog = productCatalog;
        }



        public void Run(SellItemsRequest request)
        {
            List<OrderItem> items = new();
            foreach (var itemRequest in request.Requests)
            {
                var product = _productCatalog.GetByName(itemRequest.ProductName);
                var orderItem = new OrderItem(product, itemRequest.Quantity);

                items.Add(orderItem);      
            }
            var order = new Order(items);
            _orderRepository.Save(order);
        }

        private static decimal Round(decimal amount)
        {
            return decimal.Round(amount, 2, System.MidpointRounding.ToPositiveInfinity);
        }
    }
}
