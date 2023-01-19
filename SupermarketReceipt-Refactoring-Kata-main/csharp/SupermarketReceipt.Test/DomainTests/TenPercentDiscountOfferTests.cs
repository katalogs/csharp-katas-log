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
            var product = new Product("product1", ProductUnit.Kilo);
            var offer = new TenPercentDiscountOffer(product);

            Assert.True(offer.IsApplicable(1));
        }
    }
}
