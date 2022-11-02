namespace Banking
{

    public class Account
    {
        public int balance { get; private set; }
        public Account()
        {            
        }
        public void Deposit(int money)
        {
            balance = 10;
        }
    }

}
