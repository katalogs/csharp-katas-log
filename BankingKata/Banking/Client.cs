using Banking.Tests.Unit;
using System.Collections.Generic;
using System.Linq;

namespace Banking
{
    /// <summary>
    /// The client class
    /// </summary>
    public class Client
    {
        /// <summary>
        /// The name
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class
        /// </summary>
        /// <param name="name">The name</param>
        /// <exception cref="NotEmptyNameException"></exception>
        public Client(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new NotEmptyNameException();

            Name = name;
            Accounts = new List<Account>();
        }

        /// <summary>
        /// Gets or sets the value of the accounts
        /// </summary>
        public IList<Account> Accounts { get; private set; }
        /// <summary>
        /// Gets or sets the value of the balance total
        /// </summary>
        public int BalanceTotal { get; set; }

        /// <summary>
        /// Adds the account using the specified account
        /// </summary>
        /// <param name="account">The account</param>
        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }

        /// <summary>
        /// Deposits the id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="amount">The </param>
        public void Deposit(long id, int amount)
        {
            try
            {
                var account = Accounts.FirstOrDefault(a => a.Id == id);
                account.Deposit(amount);
                BalanceTotal += amount;
            }
            catch (NegativeDepositException)
            {
                throw;
            }            
        }
    }
}
