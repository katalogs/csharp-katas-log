using Xunit;

namespace Converter.Tests
{
    public class NumberConverterTests
    {
        [Fact]
        public void When_0_Returns_Zero()
        {
            NumberConverter converter = new NumberConverter();
            var result = converter.ConvertToString(0);
            Assert.Equal("zero", result);
        }

        [Theory]
        [InlineData(1, "un")]
        [InlineData(2, "deux")]
        [InlineData(3, "trois")]
        [InlineData(4, "quatre")]
        [InlineData(5, "cinq")]
        [InlineData(6, "six")]
        [InlineData(7, "sept")]
        [InlineData(8, "huit")]
        [InlineData(9, "neuf")]
        [InlineData(10, "dix")]
        [InlineData(11, "onze")]
        [InlineData(12, "douze")]
        [InlineData(13, "treize")]
        [InlineData(14, "quatorze")]
        [InlineData(15, "quinze")]
        [InlineData(16, "seize")]

        public void When_NumberBetween1_16_Success(int number, string expected)
        {
            NumberConverter converter = new NumberConverter();
            var result = converter.ConvertToString(number);
            Assert.Equal(expected, result);
        }

    }
}
