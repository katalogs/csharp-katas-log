using NombresEnFrancais;
using Xunit;

namespace NombresEnFrancaisTests
{
    public class GetNumberInFrenchTests
    {
        [Fact]
        public void GetNumberInFrench_When0_ReturnsZero()
        {
            int zero = 0;

            string result = NumberInFrench.GetNumberInFrench(zero);

            Assert.Equal("zero", result);
        }

        [Fact]
        public void GetNumberInFrench_When1_ReturnsUn()
        {
            int un = 1;

            string result = NumberInFrench.GetNumberInFrench(un);

            Assert.Equal("un", result);
        }

        [Theory]
        [InlineData(2, "deux")]
        [InlineData(3, "trois")]
        [InlineData(4, "quatre")]
        [InlineData(5, "cinq")]
        [InlineData(6, "six")]
        [InlineData(7, "sept")]
        [InlineData(8, "huit")]
        [InlineData(9, "neuf")]
        public void GetNumberInFrench_WhenUnit_ReturnsAsString(int number, string expected)
        {
            string result = NumberInFrench.GetNumberInFrench(number);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(11, "onze")]
        [InlineData(12, "douze")]
        [InlineData(13, "treize")]
        [InlineData(14, "quatorze")]
        [InlineData(15, "quinze")]
        [InlineData(16, "seize")]
        [InlineData(17, "dix-sept")]
        [InlineData(18, "dix-huit")]
        [InlineData(19, "dix-neuf")]
        public void GetTeensNumbersInFrench_WhenTeens_ReturnsAsString(int number, string expected)
        {
            string result = NumberInFrench.GetNumberInFrench(number);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, "dix")]
        [InlineData(20, "vingt")]
        [InlineData(30, "trente")]
        [InlineData(40, "quarante")]
        [InlineData(50, "cinquante")]
        [InlineData(60, "soixante")]
        public void GetTensInFrench_WhenTens_ReturnsAsString(int number, string expected)
        {
            string result = NumberInFrench.GetNumberInFrench(number);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(21, "vingt-et-un")]
        [InlineData(31, "trente-et-un")]
        [InlineData(41, "quarante-et-un")]
        [InlineData(51, "cinquante-et-un")]
        [InlineData(61, "soixante-et-un")]
        public void Get_EveryNumber_AboveEleven_BelowSeventy_FinishingByOne_WithEtAsSeparator(int number, string expected)
        {
            string result = NumberInFrench.GetNumberInFrench(number);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(22, "vingt-deux")]
        [InlineData(23, "vingt-trois")]
        [InlineData(24, "vingt-quatre")]
        [InlineData(25, "vingt-cinq")]
        [InlineData(36, "trente-six")]
        [InlineData(47, "quarante-sept")]
        [InlineData(58, "cinquante-huit")]
        [InlineData(69, "soixante-neuf")]
        public void Get_EveryNumber_AboveTwentyOne_AndBelowSeventy_InFrench_NominalCase_ReturnsTensAndUnitAsString(int number, string expected)
        {
            string result = NumberInFrench.GetNumberInFrench(number);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(70, "soixante-dix")]
        public void Get70InFrench_ReturnsAsString(int number, string expected)
        {
            string result = NumberInFrench.GetNumberInFrench(number);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(72, "soixante-douze")]
        [InlineData(73, "soixante-treize")]
        [InlineData(74, "soixante-quatorze")]
        [InlineData(75, "soixante-quinze")]
        [InlineData(76, "soixante-seize")]
        public void GetNumberInFrench_Between72And76_ReturnsAsString(int number, string expected)
        {
            string result = NumberInFrench.GetNumberInFrench(number);

            Assert.Equal(expected, result);
        }
    }
}
