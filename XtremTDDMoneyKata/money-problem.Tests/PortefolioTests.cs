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
    }
}
