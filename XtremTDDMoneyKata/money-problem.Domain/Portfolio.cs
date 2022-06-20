using money_problem.Domain;

namespace money_problem.Tests
{
    public class Portfolio
    {
        private IDictionary<Currency, double> _moneys = new Dictionary<Currency, double>();

        private readonly Bank _bank;

        public Portfolio(Bank bank)
        {
            _bank = bank;
        }

        public void Add(Currency currency, double amount)
        {
            _moneys.Add(currency, amount);
        }

        public double Evaluate(Currency currency)
        {
            double totalAmount = 0;

            foreach (var money in _moneys )
            {
                totalAmount += _bank.Convert(money.Value, money.Key, currency);
            }
            return totalAmount;
        }
    }
}
