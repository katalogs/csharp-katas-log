using System.Runtime.CompilerServices;
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

        private Portfolio(Bank bank, IEnumerable<Money> moneys)
        {
            _bank = bank;
            _moneys = moneys.ToList();
        }

        public Portfolio Add(Money money)
        {
            return new Portfolio(_bank, _moneys.Concat(new List<Money>{money}));
        }

        public Money Evaluate(Currency currency)
        {
            return _moneys.Select(m => _bank.Convert(m, currency)).Aggregate((money1, money2) => money1 + money2);
        }
    }
}
