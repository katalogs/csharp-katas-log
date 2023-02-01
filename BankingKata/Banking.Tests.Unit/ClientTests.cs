using Moq;
using Xunit;

namespace Banking.Tests.Unit
{

    /// <summary>
    /// The client tests class
    /// </summary>
    public class ClientTests
    {
        /// <summary>
        /// Tests that should have a name in client info
        /// </summary>
        [Fact]
        public void Should_have_a_name_in_client_info()
        {
            //Arrange
            const string name = "Thomas";
            //Act
            Client client = new Client(name);
            //Assert
            Assert.NotNull(client);
            Assert.Equal(name, client.Name);
        }

        /// <summary>
        /// Tests that should not have an empty name in client should throw not empty name exception
        /// </summary>
        [Fact]
        public void Should_not_have_an_empty_name_in_client_should_throw_NotEmptyNameException()
        {
            //Arrange
            string name = string.Empty;
            //Act
            //Assert
            Assert.Throws<NotEmptyNameException>(() => new Client(name));
        }

        /// <summary>
        /// Tests that should not have an null name in client should throw not empty name exception
        /// </summary>
        [Fact]
        public void Should_not_have_an_null_name_in_client_should_throw_NotEmptyNameException()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<NotEmptyNameException>(() => new Client(null));
        }

        /// <summary>
        /// Tests that client should have no account by default
        /// </summary>
        [Fact]
        public void Client_Should_Have_No_Account_By_Default()
        {
            //Arrange
            string name = "Alexis";

            //Act
            Client client = new Client(name);

            //Assert
            Assert.NotNull(client);
            Assert.Empty(client.Accounts);
        }

        /// <summary>
        /// Tests that when we add an account to client the client should have one account
        /// </summary>
        [Fact]
        public void When_We_Add_An_Account_To_Client_The_Client_Should_Have_One_Account()
        {
            //Arrange
            string name = "Alexis";

            //Act
            Client client = new Client(name);
            Account account = new StandardAccount();
            client.AddAccount(account);

            //Assert
            Assert.NotNull(client);
            Assert.NotEmpty(client.Accounts);
            Assert.Equal(1, client.Accounts.Count);
        }

        /// <summary>
        /// Tests that when we add an account to client the client should have many account
        /// </summary>
        [Fact]
        public void When_We_Add_An_Account_To_Client_The_Client_Should_Have_Many_Account()
        {
            //Arrange
            string name = "Alexis";

            //Act
            Client client = new Client(name);
            client.AddAccount(new StandardAccount());
            client.AddAccount(new WalletAccount());

            //Assert
            Assert.NotNull(client);
            Assert.NotEmpty(client.Accounts);
            Assert.Equal(2, client.Accounts.Count);
        }

        /// <summary>
        /// Tests that when client makes deposit account should have correct balance
        /// </summary>
        [Fact]
        public void When_Client_Makes_Deposit_Account_Should_Have_Correct_Balance()
        {
            //Arrange
            string name = "Alexis";

            //Act
            Client client = new Client(name);
            Mock<Account> mockedStandardAccount = new Mock<Account>();
            mockedStandardAccount.SetupGet(x => x.Id)
                .Returns(1);

            client.AddAccount(mockedStandardAccount.Object);
            client.Deposit(mockedStandardAccount.Object.Id, 200);

            //Assert
            Assert.NotNull(client);
            Assert.NotEmpty(client.Accounts);
            Assert.Equal(1, client.Accounts.Count);
            Assert.Equal(200, client.BalanceTotal);
        }

        /// <summary>
        /// Tests that when client makes negative deposit account should throw negative deposit exception
        /// </summary>
        [Theory]
        [InlineData(-200)]
        [InlineData(0)]
        public void When_Client_Makes_Invalid_Deposit_Account_Should_Throw_Invalid_Deposit_Exception(int amount)
        {
            //Arrange
            string name = "Alexis";

            //Act
            Client client = new Client(name);
            Mock<Account> mockedStandardAccount = new Mock<Account>();
            mockedStandardAccount.SetupGet(x => x.Id)
                .Returns(2);
            mockedStandardAccount.Setup(_ => _.Deposit(It.IsAny<int>())).Throws(new InvalidDepositException());

            client.AddAccount(mockedStandardAccount.Object);

            //Assert
            Assert.Throws<InvalidDepositException>(() => client.Deposit(mockedStandardAccount.Object.Id, amount));
        }

        /// <summary>
        /// Tests that when client makes deposit on invalid account should throw invalid account exception
        /// </summary>
        [Fact]
        public void When_Client_Makes_Deposit_On_Invalid_Account_Should_Throw_Invalid_Account_Exception()
        {
            //Arrange
            string name = "Alexis";

            //Act
            Client client = new Client(name);
            Mock<Account> mockedStandardAccount = new Mock<Account>();
            mockedStandardAccount.SetupGet(x => x.Id)
                .Returns(2);

            client.AddAccount(mockedStandardAccount.Object);

            //Assert
            Assert.Throws<InvalidAccountException>(() => client.Deposit(1, 50));
        }

    }
}
