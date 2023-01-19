using SupermarketReceipt.Domain;
using SupermarketReceipt.Domain.Offer;
using Xunit;

namespace SupermarketReceipt.Test.DomainTests
{
    public class ThreeForTwoOfferTests
    {
        [Fact]
        public void Should_be_applicable_when_3_product()
        {
            var product = new Product("product1", ProductUnit.Kilo);
            var offer = new ThreeForTwoOffer(product);

            Assert.True(offer.IsApplicable(3));
        }

        [Fact]
        public void Should_be_applicable_when_1_product()
        {
            var product = new Product("product1", ProductUnit.Kilo);
            var offer = new ThreeForTwoOffer(product);

            Assert.False(offer.IsApplicable(1));
        }

        [Fact]
        public void Should_create_discount()
        {
            var product = new Product("product1", ProductUnit.Kilo);
            var offer = new ThreeForTwoOffer(product);

            var discount = offer.CreateDiscount(3, 3, 2);

            Assert.Equal(-2, discount.DiscountAmount);
        }
    }
}
