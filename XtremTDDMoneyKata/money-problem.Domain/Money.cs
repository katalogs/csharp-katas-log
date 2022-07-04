using System.ComponentModel.Design;
using money_problem.Tests;

namespace money_problem.Domain;

public record Money (double Amount, Currency Currency)
{
    public Money Times( int times) => this with {Amount = this.Amount * times};

    public Money Divide(int divisor)=> this with {Amount = this.Amount / divisor};

    public Money Add(Money money)
    {
        if (this.Currency != money.Currency) throw new InvalidMoneyOperationException();
        return this with {Amount = this.Amount + money.Amount};
    }
}
