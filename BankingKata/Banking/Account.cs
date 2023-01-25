using System;

namespace Banking
{

    /// <summary>
    /// The account class
    /// </summary>
    public abstract class Account
    {
        /// <summary>
        /// Gets or sets the value of the id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Deposits the amount
        /// </summary>
        /// <param name="amount">The amount</param>
        public void Deposit(int amount)
        {
            throw new NotImplementedException();
        }
    }

}
