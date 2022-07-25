namespace money_problem.Domain
{
    public sealed class Bank
    {
        private readonly Dictionary<string, double> _exchangeRates;

        private Bank(Dictionary<string, double> exchangeRates) => _exchangeRates = exchangeRates;

        public static Bank WithExchangeRate(Currency from, Currency to, double rate)
        {
            var bank = new Bank(new Dictionary<string, double>());

            return bank.AddExchangeRate(from, to, rate);
        }

        public Bank AddExchangeRate(Currency from, Currency to, double rate)
        {
            return new Bank(_exchangeRates.Concat(new Dictionary<string, double> { { KeyFor(from, to), rate } })
                .ToDictionary(x => x.Key, x => x.Value));
        }

        private static string KeyFor(Currency from, Currency to) => $"{from}->{to}";

        private double ConvertSafely(double amount, Currency from, Currency to) =>
            to == from
                ? amount
                : amount * _exchangeRates[KeyFor(from, to)];

        private bool CanConvert(Currency from, Currency to) =>
            from == to || _exchangeRates.ContainsKey(KeyFor(from, to));

        public Money Convert(Money money, Currency currency)
        {
            if (CanConvert(money.Currency, currency))
            {
                return new Money(ConvertSafely(money.Amount, money.Currency, currency), currency);
            }

            throw new MissingExchangeRateException(money.Currency, currency);

        }
    }
}
