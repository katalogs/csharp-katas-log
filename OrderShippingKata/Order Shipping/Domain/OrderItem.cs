﻿using Ardalis.GuardClauses;
using OrderShipping.Domain.Exception;

namespace OrderShipping.Domain
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TaxedAmount => Round(this.Product.UnitaryTaxedAmount * this.Quantity);
        public decimal Tax => Round(this.Product.UnitaryTax * this.Quantity);

        public OrderItem(Product product, int quantity)
        {
            Product = product ?? throw new UnknownProductException();
            Quantity = Guard.Against.NegativeOrZero(quantity);
        }

        private static decimal Round(decimal amount)
        {
            return decimal.Round(amount, 2, System.MidpointRounding.ToPositiveInfinity);
        }
    }
}
