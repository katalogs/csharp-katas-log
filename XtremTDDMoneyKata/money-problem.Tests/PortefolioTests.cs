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
            portfolio.Add(USD, 5);
            portfolio.Add(EUR, 10);
            double expectedAmount = portfolio.Evaluate(USD);
            Assert.Equal(17, expectedAmount);
        }

        [Fact(DisplayName = "1 USD + 1100 KRW = 2200 KRW")]
        public void AddUSDToKRW()
        {
            Portfolio portfolio = new(Bank.WithExchangeRate(USD, KRW, 1100));
            portfolio.Add(USD, 1);
            portfolio.Add(KRW, 1100);
            double expectedAmount = portfolio.Evaluate(KRW);
            Assert.Equal(2200, expectedAmount);
        }

        [Fact(DisplayName = "1 USD + 2 USD + 1100 KRW = 4400 KRW")]
        public void AddTwoUSDMoneyToKRW()
        {
            Portfolio portfolio = new(Bank.WithExchangeRate(USD, KRW, 1100));
            portfolio.Add(USD, 1);
            portfolio.Add(USD, 2);
            portfolio.Add(KRW, 1100);
            double expectedAmount = portfolio.Evaluate(KRW);
            Assert.Equal(4400, expectedAmount);
        }

        [Fact(DisplayName = "Cannot convert unknown currency exchange rate")]
        public void should_throw_when_currency_exchange_rate_is_missing()
        {
            Portfolio portfolio = new(Bank.WithExchangeRate(USD, KRW, 1100));
            portfolio.Add(EUR, 1);
            portfolio.Add(KRW, 1100);
            Assert.Throws<MissingExchangeRateException>(() => portfolio.Evaluate(KRW));
        }

        [Fact(DisplayName = "5 USD + 10 USD = 15 USD")]
        public void AddInUsd()
        {
            Portfolio portfolio = new(Bank.WithExchangeRate(USD, KRW, 1100));
            portfolio.Add(USD, 5);
            portfolio.Add(USD, 10);
            portfolio.Evaluate(USD).Should().Be(15);
        }
    }
}
