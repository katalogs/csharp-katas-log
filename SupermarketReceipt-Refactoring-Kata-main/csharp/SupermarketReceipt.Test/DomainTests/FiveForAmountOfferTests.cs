using SupermarketReceipt.Domain;
using SupermarketReceipt.Domain.Offer;
using Xunit;

namespace SupermarketReceipt.Test.DomainTests
{
    public class FiveForAmountOfferTests
    {
        private readonly XForAmountOffer _offer;
        
        public FiveForAmountOfferTests()
        {
              var product = new Product("product1", ProductUnit.Kilo);
              _offer = new FiveForAmountOffer(product, 10);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        public void Should_be_applicable_when_more_than_5_product(double quantity)
            => Assert.True(_offer.IsApplicable(quantity));


        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Should_be_applicable_when_less_than_5_product(double quantity)
            => Assert.False(_offer.IsApplicable(quantity));


        [Fact]
        public void Should_create_discount()
        {
            var actual = _offer.CreateDiscount(5, 5);
            Assert.Equal(10-5*5 , actual.DiscountAmount);
            Assert.Equal("5 for 10", actual.Description);
        }

        [Fact]
        public void Should_create_discount_Twice()
        {
            var actual = _offer.CreateDiscount(10, 5);
            Assert.Equal((10 - 5 * 5) *2, actual.DiscountAmount);
            Assert.Equal("5 for 10", actual.Description);
        }

        [Fact]
        public void Should_create_discount_only_for_5()
        {
            var actual = _offer.CreateDiscount(7, 5);
            Assert.Equal(10 - 5 * 5, actual.DiscountAmount);
            Assert.Equal("5 for 10", actual.Description);
        }
    }
}
