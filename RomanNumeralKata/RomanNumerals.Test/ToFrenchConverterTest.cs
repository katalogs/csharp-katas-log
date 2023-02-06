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
        [InlineData(10, "Dix")]
        [InlineData(11, "Onze")]
        [InlineData(12, "Douze")]
        [InlineData(13, "Treize")]
        [InlineData(14, "Quatorze")]
        [InlineData(15, "Quinze")]
        [InlineData(16, "Seize")]
        [InlineData(20, "Vingt")]
        [InlineData(30, "Trente")]
        [InlineData(40, "Quarante")]
        [InlineData(50, "Cinquante")]
        [InlineData(60, "Soixante")]
        public void ShouldReturnsExpectedConstantNumbers(int unit, string expected)
        {
            var converter = new ToFrenchConverter();

            string res = converter.Convert(unit);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(17, "Dix-sept")]
        [InlineData(18, "Dix-huit")]
        [InlineData(19, "Dix-neuf")]
        [InlineData(23, "Vingt-trois")]
        [InlineData(35, "Trente-cinq")]

        public void ShouldReturnsExpected_Dizaine_Unit(int unit, string expected)
        {
            var converter = new ToFrenchConverter();

            string res = converter.Convert(unit);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData(21, "Vingt-et-un")]
        [InlineData(31, "Trente-et-un")]
        [InlineData(41, "Quarante-et-un")]
        public void ShouldReturnsExpected_Dizaine_Unit_One(int unit, string expected)
        {
            var converter = new ToFrenchConverter();

            string res = converter.Convert(unit);

            Assert.Equal(expected, res);
        }
    }
}
