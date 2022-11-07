using OrderShipping.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderShippingTest.Domain
{
    public class ProductTest
    {
        [Fact]
        public void Calculate_UnitaryTax()
        {
            // arrange
            // Round(this.Price / 100m * this.Category.TaxPercentage);
            var food = new Category
            {
                Name = "food",
                TaxPercentage = 10m
            };
            var product = new Product
            {
                Name = "salad",
                Price = 3.56m,
                Category = food
            };

            // assert 
            Assert.Equal("salad", product.Name);
            Assert.Equal(3.56m, product.Price);
            Assert.Equal(0.36m, product.UnitaryTax);
        }
    }
}
