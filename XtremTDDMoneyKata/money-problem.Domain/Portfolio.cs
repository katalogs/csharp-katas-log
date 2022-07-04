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

        public void Add(Money money)
        {
            _moneys.Add(money);
        }

        public Money Evaluate(Currency currency)
        {
            double totalAmount = 0;

            foreach (var money in _moneys )
            {
                totalAmount += _bank.Convert(new Money(money.Amount, money.Currency), currency).Amount;
            }
            return new Money(totalAmount, currency);
        }
    }
}
