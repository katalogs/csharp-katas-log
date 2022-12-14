using Xunit;

namespace Banking.Tests.Unit
{
    public class ClientTests
    {
        [Fact]
        public void Should_have_a_name_in_client_info()
        {
            //Arrange
            string name = "Thomas";

            //Act
            Client client = new Client(name);

            //Assert
            Assert.NotNull(client);
            Assert.Equal(name, client.Name);
        }
    }
}
