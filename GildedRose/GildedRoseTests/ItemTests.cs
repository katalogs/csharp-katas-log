using GildedRoseKata;

namespace GildedRoseTests
{
    [UsesVerify]
    public class ItemTests
    {

        [Fact]
        public void Item_ShouldDecrementQuality()
        {
            var item = new Item { Quality = 10 };
            item.DecrementQuality();
            Assert.Equal(9, item.Quality);
        }

        [Fact]
        public void Item_ShouldNotDecrementQuality_BelowZero()
        {
            var item = new Item { Quality = 0 };
            item.DecrementQuality();
            Assert.Equal(0, item.Quality);
        }
    }
}
