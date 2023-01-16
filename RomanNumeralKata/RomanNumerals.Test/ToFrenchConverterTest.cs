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

        [Fact]
        public void When_1_ShouldReturns_Un()
        {
            var converter = new ToFrenchConverter();

            string res = converter.Convert(1);

            Assert.Equal("Un", res);
        }

        [Theory]
        [InlineData(2, "Deux")]
        [InlineData(3, "Trois")]
        [InlineData(4, "Quatre")]
        [InlineData(5, "Cinq")]
        [InlineData(6, "Six")]
        [InlineData(7, "Sept")]
        [InlineData(8, "Huit")]
        [InlineData(9, "Neuf")]
        public void ShouldReturnsExpectedUnit(int unit, string expected)
        {
            var converter = new ToFrenchConverter();

            string res = converter.Convert(unit);

            Assert.Equal(expected, res);
        }
    }
}
