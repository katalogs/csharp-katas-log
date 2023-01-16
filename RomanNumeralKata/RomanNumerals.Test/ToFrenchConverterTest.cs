using Xunit;

namespace RomanNumerals.Test
{
    public class ToFrenchConverterTest
    {
        [Fact]
        public void When_0_ShouldReturns_Zero()
        {
            var converter = new ToFrenchConverter();

            string res = converter.Convert(0);

            Assert.Equal("Zéro", res);
        }
    }
}
