using Xunit;
namespace Banking.Tests.Unit
{
    public class BankingTest
    {
        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        public void Deposite_Euro_Should_Add_Euro_To_Balance(long money)
        {
            //Arrange
            Account account = new Account();
            long moneyInCentime = money * 100;

            //Act
            account.Deposit(moneyInCentime);
            
            //Assert
            Assert.Equal(account.Balance, moneyInCentime);
        }
        
        [Fact]
        public void Deposite_Many_Time_Euro_Should_Increment_Balance()
        {
            //Arrange
            Account account = new Account();
            long money = 10;
            long moneyInCentime = money * 100;

            long balanceExpected = 2000;

            //Act
            account.Deposit(moneyInCentime);
            account.Deposit(moneyInCentime);
            
            //Assert
            Assert.Equal(account.Balance, balanceExpected);
        }
        
        [Fact]
        public void Withdraw_Euro_Should_Decrement_Balance()
        {
            //Arrange
            Account account = new Account();
            long money = 10;
            long moneyInCentime = money * 100;

            long balanceExpected = 0;

            //Act
            account.Deposit(moneyInCentime);
            account.Withdraw(moneyInCentime);
            
            //Assert
            Assert.Equal(account.Balance, balanceExpected);
        }
    }
}
