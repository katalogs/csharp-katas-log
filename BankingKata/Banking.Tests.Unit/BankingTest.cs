using Xunit;

namespace Banking.Tests.Unit
{

    public class BankingTest
    {
        [Fact]
        public void Deposite_10_Euro_Should_Add_10_To_Balance(){
            
            //Arrange
            const int money = 10;
            const int balance = 0;
            const string accountToSend = "accountToDepose";
            Account account = new Account(balance);
            
            //Act
            var result = account.SendMoney(money, accountToSend);
            
            //Assert
            Assert.Equal(result, money);
        }
    }
}
