using GildedRoseKata;

namespace GildedRoseTests
{
    public class ConjuredTests
    {
        [Fact]
        public void ConjuredTest_When_UpdateQuality_Then_QualityDecreaseTwice()
        {
            //Arrange
            var item = new Conjured("Mana Cake", 3, 6);

            //Act
            item.UpdateQuality();

            //Assert
            Assert.Equal(4,item.Quality);
        }

        [Fact]
        public void ConjuredTest_When_UpdateQualityIsEqualToOne_Then_QualityCantDecrease()
        {
            //Arrange
            var item = new Conjured("Mana Cake", 3, 1);

            //Act
            item.UpdateQuality();

            //Assert
            Assert.Equal(0,item.Quality);
        }

        [Fact]
        public void ConjuredTest_When_AnItemIsConjured_Then_ShouldHaveConjuredInItsName()
        {
            //Arrange & Act
            var item = new Conjured("Mana Cake", 3, 6);

            //Assert
            Assert.Equal("Conjured Mana Cake", item.Name);
        }
    }
}
