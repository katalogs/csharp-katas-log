﻿using OrderShipping.UseCase;

namespace OrderShipping.Domain
{
    public class Order
    {
        public decimal Total { get; set; }
        public string Currency { get; set; }
        public IList<OrderItem> Items { get; set; }
        public decimal Tax { get; set; }
        public OrderStatus Status { get; set; }
        public int Id { get; set; }

        private void StatusCanBeChanged(OrderApprovalRequest request)
        {
            if (this.Status == OrderStatus.Shipped)
            {
                throw new ShippedOrdersCannotBeChangedException();
            }

            if (request.Approved && this.Status == OrderStatus.Rejected)
            {
                throw new RejectedOrderCannotBeApprovedException();
            }

            if (!request.Approved && this.Status == OrderStatus.Approved)
            {
                throw new ApprovedOrderCannotBeRejectedException();
            }
        }

        public void ChangeStatus(OrderApprovalRequest request)
        {
            StatusCanBeChanged(request);

            this.Status = request.Approved ? OrderStatus.Approved : OrderStatus.Rejected;
        }

        internal void AddOrderItem(OrderItem orderItem)
        {
            this.Items.Add(orderItem);
            this.Total += orderItem.TaxedAmount;
            this.Tax += Round(orderItem.Product.GetTax() * orderItem.Quantity);
        }

        private static decimal Round(decimal amount)
        {
            return decimal.Round(amount, 2, System.MidpointRounding.ToPositiveInfinity);
        }
    }
}
