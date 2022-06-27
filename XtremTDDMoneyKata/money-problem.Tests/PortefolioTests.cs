using FluentAssertions;
using money_problem.Domain;
using Xunit;
using static money_problem.Domain.Currency;

namespace money_problem.Tests
{
    public class PortefolioTests
    {
        [Fact(DisplayName = "5 USD + 10 EUR = 17 USD")]
        public void AddEurosToUSD()
        {
            Portfolio portfolio = new(Bank.WithExchangeRate(EUR, USD, 1.2));
            portfolio.Add(new Money(5, USD));
            portfolio.Add(new Money(10, EUR));
            Money expectedMoney = portfolio.Evaluate(USD);
            Assert.Equal(new Money(17, USD), expectedMoney);
        }

        [Fact(DisplayName = "1 USD + 1100 KRW = 2200 KRW")]
        public void AddUSDToKRW()
        {
            Portfolio portfolio = new(Bank.WithExchangeRate(USD, KRW, 1100));
            portfolio.Add(new Money(1, USD));
            portfolio.Add(new Money(1100, KRW));
            var expectedAmount = portfolio.Evaluate(KRW);
            Assert.Equal(new Money(2200, KRW), expectedAmount);
        }

        [Fact(DisplayName = "1 USD + 2 USD + 1100 KRW = 4400 KRW")]
        public void AddTwoUSDMoneyToKRW()
        {
            Portfolio portfolio = new(Bank.WithExchangeRate(USD, KRW, 1100));
            portfolio.Add(new Money(1, USD));
            portfolio.Add(new Money(2, USD));
            portfolio.Add(new Money(1100, KRW));
            var expectedAmount = portfolio.Evaluate(KRW);
            Assert.Equal(new Money(4400, KRW), expectedAmount);
        }

        [Fact(DisplayName = "Cannot convert unknown currency exchange rate")]
        public void should_throw_when_currency_exchange_rate_is_missing()
        {
            Portfolio portfolio = new(Bank.WithExchangeRate(USD, KRW, 1100));
            portfolio.Add(new Money(1, EUR));
            portfolio.Add(new Money(1100, KRW));
            Assert.Throws<MissingExchangeRateException>(() => portfolio.Evaluate(KRW));
        }

        [Fact(DisplayName = "5 USD + 10 USD = 15 USD")]
        public void AddInUsd()
        {
            Portfolio portfolio = new(Bank.WithExchangeRate(USD, KRW, 1100));
            portfolio.Add(new Money(5, USD));
            portfolio.Add(new Money(10, USD));
            portfolio.Evaluate(USD).Should().Be(new Money(15, USD));
        }
    }
}
