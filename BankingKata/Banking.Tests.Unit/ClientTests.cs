using Xunit;
using System.Linq;

namespace Banking.Tests.Unit
{
    public class ClientTests
    {
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

        [Fact]
        public void Should_not_have_an_empty_name_in_client_should_throw_NotEmptyNameException()
        {
            //Arrange
            string name = string.Empty;
            //Act
            //Assert
            Assert.Throws<NotEmptyNameException>(() => new Client(name));
        }

        [Fact]
        public void Should_not_have_an_null_name_in_client_should_throw_NotEmptyNameException()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<NotEmptyNameException>(() => new Client(null));
        }

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

        [Fact]
        public void When_We_Add_An_Account_To_Client_The_Client_Should_Have_One_Account()
        {
            //Arrange
            string name = "Alexis";

            //Act
            Client client = new Client(name);
            Account account = new Account();
            client.AddAccount(account);

            //Assert
            Assert.NotNull(client);
            Assert.NotEmpty(client.Accounts);
            Assert.Equal(1, client.Accounts.Count);
        }
    }
}
