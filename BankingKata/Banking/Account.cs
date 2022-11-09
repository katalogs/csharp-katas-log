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
            Balance = depot;
        }
    }

}
