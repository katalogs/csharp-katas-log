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
    }
}
