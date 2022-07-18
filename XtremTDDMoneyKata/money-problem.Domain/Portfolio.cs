using money_problem.Domain;

namespace money_problem.Tests
{
    public class Portfolio
    {
        private readonly List<Money> _moneys = new();

        private readonly Bank _bank;

        public Portfolio(Bank bank)
        {
            _bank = bank;
        }

        public Portfolio Add(Money money)
        {
           _moneys.Add(money);
           return this;
        }

        public Money Evaluate(Currency currency)
        {
            return _moneys.Select(m => _bank.Convert(m, currency)).Aggregate((money1, money2) => money1 + money2);
        }
    }
}
