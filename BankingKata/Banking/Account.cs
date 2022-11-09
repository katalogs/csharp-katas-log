namespace Banking
{
    public class Account
    {
        
        /// <summary>
        /// Blance in centimes
        /// </summary>
        public long Balance { get; private set; }


        public Account()
        {            
        }

        /// <summary>
        /// Deposit money in account with centimes
        /// </summary>
        /// <param name="depot">The depot</param>
        public void Deposit(long depot)
        {
            Balance += depot;
        }

        /// <summary>
        /// Withdraw money in account with centimes
        /// </summary>
        /// <param name="withdraw"></param>
        public void Withdraw(long withdraw)
        {
            throw new System.NotImplementedException();
        }
    }

}
