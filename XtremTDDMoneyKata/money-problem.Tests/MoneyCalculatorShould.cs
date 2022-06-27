using FluentAssertions;
using money_problem.Domain;
using Xunit;
using static money_problem.Domain.Currency;

namespace money_problem.Tests
{
    public class MoneyShould
    {
        [Fact(DisplayName = "10 EUR x 2 = 20 EUR")]
        public void MultiplyInEuros()
        {
            new Money(10, EUR)
                .Times(2)
                .Should()
                .Be(new Money(20, EUR));
        }

        [Fact(DisplayName = "4002 KRW / 4 = 1000.5 KRW")]
        public void DivideInKoreanWons()
        {
            new Money(4002, KRW)
                .Divide( 4)
                .Should()
                .Be(new Money(1000.5d, KRW));
        }
    }
}
