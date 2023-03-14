﻿using System;

namespace SupermarketReceipt.ComputeOffer
{
    public class ShoppingCartItem
    {
        public ShoppingCartItem(Product product, double weight)
        {
            Product = product;
            Quantity = weight;
        }

        public Product Product { get; }
        public double Quantity { get; private set; }

        internal void IncreaseQuantity(double quantity)
        {
            Quantity += quantity;
        }
    }
}
