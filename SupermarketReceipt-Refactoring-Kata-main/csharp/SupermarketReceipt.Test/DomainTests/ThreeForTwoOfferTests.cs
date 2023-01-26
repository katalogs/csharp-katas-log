using SupermarketReceipt.Domain;
using SupermarketReceipt.Domain.Offer;
using Xunit;

namespace SupermarketReceipt.Test.DomainTests
{
    public class ThreeForTwoOfferTests
    {
        private readonly ThreeForTwoOffer _offer;

        public ThreeForTwoOfferTests()
        {
            var product = new Product("product1", ProductUnit.Kilo);
            _offer  = new ThreeForTwoOffer(product);
        }
        [Fact]
        public void Should_be_applicable_when_3_product()
            => Assert.True(_offer.IsApplicable(3));

        [Fact]
        public void Should_be_not_applicable_when_1_product()
            => Assert.False(_offer.IsApplicable(1));

        [Fact]
        public void Should_create_discount()
        {
            var discount = _offer.CreateDiscount(3, 2);
            Assert.Equal(-2, discount.DiscountAmount);
        }

        [Fact]
        public void Should_create_discount_twice()
        {
            var actual = _offer.CreateDiscount(6, 2);
            Assert.Equal(-2 * 2, actual.DiscountAmount);
            Assert.Equal("3 for 2", actual.Description);
        }

        [Fact]
        public void Should_create_only_one_discount()
        {
            var actual = _offer.CreateDiscount(4, 2);
            Assert.Equal(-2, actual.DiscountAmount);
            Assert.Equal("3 for 2", actual.Description);
        }
    }
}
