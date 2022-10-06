using Xunit;

namespace Converter.Tests
{
    public class NumberConverterTests
    {
        private NumberConverter _converter;

        public NumberConverterTests()
        {
            _converter = new NumberConverter();
        }

        [Fact]
        public void When_0_Returns_Zero()
        {
            var result = _converter.ConvertToString(0);
            Assert.Equal("Zéro", result);
        }

        [Theory]
        [InlineData(1, "Un")]
        [InlineData(2, "Deux")]
        [InlineData(3, "Trois")]
        [InlineData(4, "Quatre")]
        [InlineData(5, "Cinq")]
        [InlineData(6, "Six")]
        [InlineData(7, "Sept")]
        [InlineData(8, "Huit")]
        [InlineData(9, "Neuf")]
        [InlineData(10, "Dix")]
        [InlineData(11, "Onze")]
        [InlineData(12, "Douze")]
        [InlineData(13, "Treize")]
        [InlineData(14, "Quatorze")]
        [InlineData(15, "Quinze")]
        [InlineData(16, "Seize")]

        public void When_NumberBetween1_16_Success(int number, string expected)
        {
            var result = _converter.ConvertToString(number);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(17, "Dix-sept")]
        [InlineData(18, "Dix-huit")]
        [InlineData(19, "Dix-neuf")]
        [InlineData(22, "Vingt-deux")]
        [InlineData(35, "Trente-cinq")]
        [InlineData(46, "Quarante-six")]
        public void When_NumberBetween16_69_Success(int number, string expected)
        {
            var result = _converter.ConvertToString(number);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(21, "Vingt-et-un")]
        [InlineData(31, "Trente-et-un")]
        [InlineData(41, "Quarante-et-un")]
        public void When_Number_is_TensAndOne_Returns_Tens_And_One(int number, string expected)
        {
            var result = _converter.ConvertToString(number);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, "Dix")]
        [InlineData(20, "Vingt")]
        [InlineData(30, "Trente")]
        [InlineData(40, "Quarante")]
        [InlineData(50, "Cinquante")]
        [InlineData(60, "Soixante")]
        public void When_NumberIsTens_ReturnsTens(int number, string expected)
        {
            var result = _converter.ConvertToString(number);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(70, "Soixante-dix")]
        [InlineData(72, "Soixante-douze")]
        [InlineData(77, "Soixante-dix-sept")]
        [InlineData(71, "Soixante-et-onze")]
        public void When_NumberIs70_ReturnsSoixante_dix(int number, string expected)
        {
            var result = _converter.ConvertToString(number);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(82, "Quatre-vingt-deux")]
        [InlineData(83, "Quatre-vingt-trois")]
        [InlineData(84, "Quatre-vingt-quatre")]
        public void When_NumberIs8x_Returns_Quatre_vingt_x(int number, string expected)
        {
            var result = _converter.ConvertToString(number);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(80, "Quatre-vingts")]
        public void When_NumberIs80_Returns_Quatre_vingts_with_s(int number, string expected)
        {
            var result = _converter.ConvertToString(number);
            Assert.Equal(expected, result);
        }
    }
}
