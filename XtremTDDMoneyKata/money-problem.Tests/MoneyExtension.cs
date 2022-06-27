using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using money_problem.Domain;

namespace money_problem.Tests;

internal static class MoneyExtension
{
    public static Money Dollars(this double amount)
    {
        return new Money(amount, Currency.USD);
    }

    public static Money Euros(this double amount)
    {
        return new Money(amount, Currency.EUR);
    }

    public static Money KoreanWons(this double amount)
    {
        return new Money(amount, Currency.KRW);
    }
}
