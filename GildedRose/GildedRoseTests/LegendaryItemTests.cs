using GildedRoseKata;

namespace GildedRoseTests
{
    public class LegendaryItemTests
    {
        [Fact]
        public void LegendaryItem_WhenUpdated_DoesNothing()
        {
            var item = new LegendaryItem("toto", 50, 2);

            item.Update();

            Assert.Equal(50, item.SellIn);
            Assert.Equal(2, item.Quality);
        }
    }
}
