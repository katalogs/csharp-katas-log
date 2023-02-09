﻿using LanguageExt.UnsafeValueAccess;
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
        public void Should_be_not_applicable_when_1_product()
            => Assert.Empty(_offer.CreateDiscountIfApplicable(1, 10));

        [Fact]
        public void Should_create_discount()
        {
            var discount = _offer.CreateDiscountIfApplicable(3, 2);
            Assert.NotEmpty(discount);
            Assert.Equal(-2, discount.ValueUnsafe().DiscountAmount);
        }

        [Fact]
        public void Should_create_discount_twice()
        {
            var actual = _offer.CreateDiscountIfApplicable(6, 2);
            Assert.NotEmpty(actual);
            Assert.Equal(-2 * 2, actual.ValueUnsafe().DiscountAmount);
            Assert.Equal("3 for 2", actual.ValueUnsafe().Description);
        }

        [Fact]
        public void Should_create_only_one_discount()
        {
            var actual = _offer.CreateDiscountIfApplicable(4, 2);
            Assert.NotEmpty(actual);
            Assert.Equal(-2, actual.ValueUnsafe().DiscountAmount);
            Assert.Equal("3 for 2", actual.ValueUnsafe() .Description);
        }
    }
}
