using SupermarketReceipt.Domain;
using SupermarketReceipt.Domain.Offer;
using Xunit;

namespace SupermarketReceipt.Test.DomainTests
{
    public class TenPercentDiscountOfferTests
    {
        private readonly TenPercentDiscountOffer _offer;

        public TenPercentDiscountOfferTests()
        {
            var product = new Product("product1", ProductUnit.Kilo);
            _offer = new TenPercentDiscountOffer(product);
        }

        [Fact]
        public void Should_be_applicable_when_1_product()
            => Assert.True(_offer.IsApplicable(1));

        [Fact]
        public void Should_not_be_applicable_when_less_than_one_product()
            => Assert.False(_offer.IsApplicable(0.5));

        [Fact]
        public void Should_create_discount_10_percent()
        {
            var actual = _offer.CreateDiscount(1, 100);
            Assert.Equal(-10, actual.DiscountAmount);
            Assert.Equal("10% off", actual.Description);
        }
    }
}
