using OrderShipping.Domain;
using OrderShipping.Repository;
using OrderShipping.UseCase.Requests;
using OrderShipping.Domain.Exceptions;

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
            Order order = new ();
            
            foreach (var itemRequest in request.Requests)
            {
                var product = _productCatalog.GetByName(itemRequest.ProductName);

                if (product == null)
                {
                    throw new UnknownProductException();
                }
                else
                {
                    order.AddItem(product, itemRequest.Quantity);
                   
                }
            }

            _orderRepository.Save(order);
        }
    }
}
