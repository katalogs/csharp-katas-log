using GildedRoseKata;

namespace GildedRoseTests
{
    [UsesVerify]
    public class ItemTests
    {
        [Fact]
        public void Item_ShouldDecrementQuality()
        {
            var item = new Item("stuff", 0, 10);
            item.DecrementQuality();
            Assert.Equal(9, item.Quality);
        }

        [Fact]
        public void Item_ShouldNotDecrementQuality_BelowZero()
        {
            var item = new Item("stuff", 0, 0);
            item.DecrementQuality();
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void Item_ShouldIncrementQuality()
        {
            var item = new Item("stuff", 0, 10);
            item.IncrementQuality();
            Assert.Equal(11, item.Quality);
        }

        [Fact]
        public void Item_ShouldNotIncrementQuality_Abovefifty()
        {
            var item = new Item("stuff", 0, 50);
            item.IncrementQuality();
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void Item_WhenSetMinimalQuality_ShouldBeZero()
        {
            var item = new Item("stuff", 0, 50);
            item.SetMinimalQuality();
            Assert.Equal(0, item.Quality);
        }
    }
}
