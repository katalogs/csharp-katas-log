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

        [Fact]
        public void Item_WhenUpdate_QualityShouldDecrease()
        {
            var item = new Item("stuff", 5, 45);
            item.Update();
            Assert.Equal(44, item.Quality);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Item_WhenUpdateAfterExpiration_QualityShouldDecreaseTwice(int sellIn)
        {
            var item = new Item("stuff", sellIn, 45);
            item.Update();
            Assert.Equal(43, item.Quality);
        }
    }
}
