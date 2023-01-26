using SupermarketReceipt.Domain;
using SupermarketReceipt.Domain.Offer;
using Xunit;

namespace SupermarketReceipt.Test.DomainTests
{
    public class TenPercentDiscountOfferTests
    {
        [Fact]
        public void Should_be_applicable_when_1_product()
        {
            var offer = PrepareOffer();
            Assert.True(offer.IsApplicable(1));
        }

        private static TenPercentDiscountOffer PrepareOffer()
        {
            var offer = PrepareOffer();
            return offer;
        }

        [Fact]
        public void Should_create_discount_10_percent()
        {
            var offer = PrepareOffer();
            var actual = offer.CreateDiscount(1, 100);
            Assert.Equal(-10, actual.DiscountAmount);
            Assert.Equal("10% off", actual.Description);
        }

        [Fact]
        public void Should_not_be_applicable_when_less_than_one_product()
        {
            var offer = PrepareOffer();
            Assert.False(offer.IsApplicable(0.5));
        }

    }
}
