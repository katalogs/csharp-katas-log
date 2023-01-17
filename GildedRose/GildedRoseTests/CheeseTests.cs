using GildedRoseKata;

namespace GildedRoseTests
{
    public class CheeseTests
    {
        [Fact]
        public void Update_IncreaseQuality_By_One()
        {
            var cheese = new Cheese("name");
            cheese.SellIn = 5;
            cheese.Quality = 2;

            cheese.Update();

            Assert.Equal(3, cheese.Quality);
        }
    }
}
