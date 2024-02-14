using FluentAssertions;
using money_problem.Domain;
using System;
using Xunit;
using static money_problem.Domain.Currency;

namespace money_problem.Tests
{
    public class PortfolioShould
    {
        private readonly Bank _bank =
            Bank.WithExchangeRate(EUR, USD, 1.2)
                .AddExchangeRate(USD, KRW, 1100);

        [Fact(DisplayName = "5 USD + 10 USD = 15 USD")]
        public void Add()
        {
            var portfolio = 5d.Dollars().AddToPortfolio(10d.Dollars());

            var evaluate = portfolio.Evaluate(_bank, USD);

            evaluate.TryPickT0(out var result , out var _);           
            result.Should().Be(15d.Dollars());           
        }

        [Fact(DisplayName = "5 USD + 10 EUR = 17 USD")]
        public void AddDollarsAndEuros()
        {
            var portfolio = 5d.Dollars().AddToPortfolio(10d.Euros());

            var evaluate = portfolio.Evaluate(_bank, USD);

            evaluate.TryPickT0(out var result, out var _);
            result.Should().Be(17d.Dollars());
        }

        [Fact(DisplayName = "1 USD + 1100 KRW = 2200 KRW")]
        public void AddDollarsAndKoreanWons()
        {
            var portfolio = 1d.Dollars().AddToPortfolio(1100d.KoreanWons());

            var evaluate = portfolio.Evaluate(_bank, KRW);

            evaluate.TryPickT0(out var result, out var _);
            result.Should().Be(2200d.KoreanWons());
        }

        [Fact(DisplayName = "Returns a MissingExchangeRatesException case of missing exchange rates")]
        public void AddWithMissingExchangeRatesShouldReturnAMissingExchangeRatesException()
        {
            var portfolio = 1d.Dollars()
                .AddToPortfolio(1d.Euros())
                .AddToPortfolio(1d.KoreanWons());

            var evaluate = portfolio.Evaluate(_bank, KRW);

            var result = evaluate.Match(money => money.Amount.ToString(), exception => exception.Message);
            result.Should().Be("Missing exchange rate(s): [EUR->KRW]");
        }
    }
}
