using GildedRoseKata;

namespace GildedRoseTests
{
    public class ConjuredTests
    {
        [Fact]
        public void ConjuredItem_WhenUpdated_ShouldDecreaseTwiceAsFast()
        {
            var item = new ConjuredItem("stuff", 10, 20);

            item.Update();

            Assert.Equal(18, item.Quality);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void ConjuredItem_WhenUpdatedWhileExpired_ShouldDecreaseFourTimes(int sellIn)
        {
            var item = new ConjuredItem("stuff", sellIn, 20);

            item.Update();

            Assert.Equal(16, item.Quality);
        }
    }
}
