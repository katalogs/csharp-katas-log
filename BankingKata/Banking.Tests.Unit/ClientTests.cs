using Xunit;

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
    }
}
