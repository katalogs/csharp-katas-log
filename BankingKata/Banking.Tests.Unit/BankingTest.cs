using System;
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

        [Fact]
        public void Deposit_10_Euro_And_Withdraw_5_Euro_Should_return_Balance_Equal_To_5_Euro()
        {
            //Arrange
            Account account = new Account();
            long money = 10;
            long moneyInCentime = money * 100;

            long balanceExpected = 500;
            long withdrawInCentime = 500;
            //Act
            account.Deposit(moneyInCentime);
            account.Withdraw(withdrawInCentime);

            //Assert
            Assert.Equal(account.Balance, balanceExpected);
        }

        [Fact]
        public void Deposit_10_Euro_And_Withdraw_15_Euro_Should_Not_Be_Possible()
        {
            //Arrange
            Account account = new Account();
            long money = 10;
            long moneyInCentime = money * 100;
            long withdrawInCentime = 1500;

            //Act
            account.Deposit(moneyInCentime);

            //Assert
            Assert.Throws<BalanceCannotBeNegativeException>(() => account.Withdraw(withdrawInCentime));
        }
    }
}
