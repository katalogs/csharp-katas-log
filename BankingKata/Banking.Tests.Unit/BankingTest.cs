using Xunit;

namespace Banking.Tests.Unit
{

    public class BankingTest
    {
        [Fact]
        public void Deposite_10_Euro_Should_Add_10_To_Balance(){
            
            //Arrange
            const int money = 10;
            Account account = new Account();
            
            //Act
            account.Deposit(money);
            
            //Assert
            Assert.Equal(account.balance, money);
        }

    }
}
